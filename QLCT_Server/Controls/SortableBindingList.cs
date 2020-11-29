using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace QLCT_Server.Controls
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private ArrayList _sortedList;
        private ArrayList _unsortedItems;
        private bool _isSortedValue;
        ListSortDirection _sortDirectionValue;
        PropertyDescriptor _sortPropertyValue;

        public SortableBindingList()
        {
        }

        public SortableBindingList(IList<T> list)
        {
            if (list == null) return;
            foreach (object o in list)
            {
                Add((T)o);
            }
        }

        protected override bool SupportsSearchingCore => true;

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
            if (key != null)
            {
                for (int i = 0; i < Count; ++i)
                {
                    var item = Items[i];
                    if (propInfo != null && propInfo.GetValue(item, null).Equals(key))
                        return i;
                }
            }
            return -1;
        }

        public int Find(string property, object key)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor prop = properties.Find(property, true);

            if (prop == null)
                return -1;
            return FindCore(prop, key);
        }

        protected override bool SupportsSortingCore => true;


        protected override bool IsSortedCore => _isSortedValue;


        protected override void ApplySortCore(PropertyDescriptor prop,
            ListSortDirection direction)
        {
            _sortedList = new ArrayList();

            Type interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType == null && prop.PropertyType.IsValueType)
            {
                Type underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);

                if (underlyingType != null)
                {
                    interfaceType = underlyingType.GetInterface("IComparable");
                }
            }

            if (interfaceType != null)
            {
                _sortPropertyValue = prop;
                _sortDirectionValue = direction;

                IEnumerable<T> query = Items;
                query = direction == ListSortDirection.Ascending ? query.OrderBy(i => prop.GetValue(i)) : query.OrderByDescending(i => prop.GetValue(i));
                int newIndex = 0;
                foreach (object item in query)
                {
                    Items[newIndex] = (T)item;
                    newIndex++;
                }
                _isSortedValue = true;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));

            }
            else
            {
                throw new NotSupportedException("Cannot sort by " + prop.Name + ". This" + prop.PropertyType + " does not implement IComparable");
            }
        }

        protected override void RemoveSortCore()
        {
            if (_unsortedItems != null)
            {
                for (int i = 0; i < _unsortedItems.Count;)
                {
                    var position = Find("LastName", _unsortedItems[i].GetType().GetProperty("LastName")?.GetValue(_unsortedItems[i], null));
                    if (position > 0 && position != i)
                    {
                        object temp = this[i];
                        this[i] = this[position];
                        this[position] = (T)temp;
                        i++;
                    }
                    else if (position == i)
                        i++;
                    else
                        _unsortedItems.RemoveAt(i);
                }
                _isSortedValue = false;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        public void RemoveSort()
        {
            RemoveSortCore();
        }

        protected override PropertyDescriptor SortPropertyCore => _sortPropertyValue;

        protected override ListSortDirection SortDirectionCore => _sortDirectionValue;
    }
}