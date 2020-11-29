using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLCT_Server.Controls
{
    public sealed class UcDataGridView : DataGridView
    {
        #region Variables

        private const string _checkBoxName = "chkBxSelect";
        private readonly List<int> _rowCurrent = new List<int>();
        private int _rowDefaultHeight = 27;
        private int _rowExpandedHeight = 300;
        private int _rowDefaultDivider = 0;
        private int _rowExpandedDivider = 300 - 22;
        private bool _collapseRow;
        private List<GridMappingData> _lstColumnMapping;
        private ContextMenu _ctmenu;
        private bool _isShowCheckBox;

        #region CheckBox

        public delegate void OnCheckBoxClicked(int rowIndex, object currentRecord, bool value);
        public event OnCheckBoxClicked EventCheckBoxClick;
        private int _totalCheckBoxes;
        private int _totalCheckedCheckBoxes;
        private CheckBox _headerCheckBox;
        private bool _isHeaderCheckBoxClicked;
        private DataGridViewCheckBoxColumn _col;
        private string _columnUnique;
        private int? _checkRowIndex = null;
        private bool? _checkValue = null;

        #endregion

        #endregion

        #region Constructor

        public UcDataGridView()
        {
            LstColumnMapping = new List<GridMappingData>();
            RowPostPaint += CModule.RowPostPaint_HeaderCount;
            MouseClick += masterControl_MouseClick;
            InitializeComponent();
            CModule.ApplyGridTheme(this, false);
            CModule.SetGridRowHeader(this, false);
            Dock = DockStyle.Fill;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllowUserToOrderColumns = true;
            AllowUserToResizeColumns = true;
            InitContextMenu();
        }

        #endregion

        #region Public

        public void SetDataSourceForList()
        {
            foreach (var col in _lstColumnMapping)
            {
                Columns.Add(new DataGridViewColumn { HeaderText = col.HeaderText, Visible = !col.IsNotViSible });
            }
        }

        public void DisplayColumn()
        {
            foreach (DataGridViewColumn column in Columns)
            {
                var col = _lstColumnMapping.FirstOrDefault(m => m.Name == column.Name);
                if (col != null)
                {
                    column.DataPropertyName = col.Name;
                    column.HeaderText = col.HeaderText;
                    column.DefaultCellStyle.Alignment = col.Align;
                    column.ReadOnly = col.IsReadOnly;
                    column.Visible = !col.IsNotViSible;
                    column.ValueType = col.TypeColumn;
                    if (!col.IsReadOnly) column.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    Columns[column.Name].Visible = false;
                }
            }
            AdjustColumnDeThiOrder();
            if (IsShowCheckBox)
            {
                _checkRowIndex = null;
                _checkValue = null;
                AddHeaderCheckBox();
            }
        }

        #region CheckBox

        public List<int> GetCheckedRow()
        {
            var lstSelect = new List<int>();
            if (Columns.Contains(_checkBoxName))
            {
                foreach (DataGridViewRow row in Rows)
                {
                    var check = ((DataGridViewCheckBoxCell)row.Cells[_checkBoxName]).Value;
                    check = check ?? false;
                    if ((bool)check)
                    {
                        try
                        {
                            object data;
                            if (string.IsNullOrEmpty(_columnUnique))
                            {
                                data = row.Cells["Id"].Value;
                            }
                            else
                            {
                                data = row.Cells[_columnUnique].Value;
                            }
                            if (data != null)
                            {
                                lstSelect.Add(Convert.ToInt32(data));
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            return lstSelect;
        }

        public List<T> GetEntitySelect<T>()
        {
            var lstSelect = new List<T>();
            if (Columns.Contains(_checkBoxName))
            {
                foreach (DataGridViewRow row in Rows)
                {
                    var check = ((DataGridViewCheckBoxCell)row.Cells[_checkBoxName]).Value;
                    check = check ?? false;
                    if ((bool)check)
                    {
                        lstSelect.Add((T)row.DataBoundItem);
                    }
                }
            }
            return lstSelect;
        }

        #endregion

        #endregion

        #region Private

        private void InitializeComponent()
        {
            //((ISupportInitialize)this).BeginInit();
            //SuspendLayout();
            //((ISupportInitialize)this).EndInit();
            //ResumeLayout(false);
        }

        private void InitContextMenu()
        {
            _ctmenu = new ContextMenu();
            MenuItem itemchon = new MenuItem();
            MenuItem itemBochon = new MenuItem();
            MenuItem itemCopy= new MenuItem();
            itemchon.Text = @"Chọn";
            itemBochon.Text = @"Bỏ chọn";
            itemCopy.Text = @"Coppy";
            _ctmenu.MenuItems.Add(itemchon);
            _ctmenu.MenuItems.Add(itemBochon);
            _ctmenu.MenuItems.Add(itemCopy);
            itemchon.Click += itemchon_Click;
            itemBochon.Click += itemBochon_Click;

        }

        private void CheckData(bool pIsCheck)
        {
            var lstRow = SelectedRows;
            if (lstRow.Count > 0)
            {
                for (int i = 0; i < lstRow.Count; i++)
                {
                    var row = lstRow[i];
                    var check = (DataGridViewCheckBoxCell)row.Cells[_checkBoxName];
                    if (pIsCheck)
                    {
                        if (!(bool)(check.Value ?? false))
                        {
                            check.Value = true;
                        }
                    }
                    else
                    {
                        if ((bool)(check.Value ?? false))
                        {
                            check.Value = false;
                        }
                    }

                }
            }
        }

        private void AdjustColumnDeThiOrder()
        {
            foreach (var item in _lstColumnMapping)
            {
                if (Columns.Contains(item.Name))
                    Columns[item.Name].DisplayIndex = item.Id;
            }
        }

        #region CheckBox

        private void AddHeaderCheckBox()
        {
            _headerCheckBox = new CheckBox();
            _headerCheckBox.Name = _checkBoxName;
            _headerCheckBox.Size = new Size(13, 13);
            if (Controls.ContainsKey(_checkBoxName))
            {
                Controls.RemoveByKey(_checkBoxName);
            }
            Controls.Add(_headerCheckBox);
            _totalCheckBoxes = RowCount;
            _totalCheckedCheckBoxes = 0;

            _col = new DataGridViewCheckBoxColumn();
            _col.HeaderText = "";
            _col.Name = _checkBoxName;
            Columns.Insert(0, _col);
            Columns[_checkBoxName].Width = 40;
            Columns[_checkBoxName].Resizable = DataGridViewTriState.False;
            Columns[_checkBoxName].DisplayIndex = 0;

            _headerCheckBox.KeyUp += HeaderCheckBox_KeyUp;
            _headerCheckBox.MouseClick += HeaderCheckBox_MouseClick;
            CellValueChanged += dgvSelectAll_CellValueChanged;
            CurrentCellDirtyStateChanged += dgvSelectAll_CurrentCellDirtyStateChanged;
            CellPainting += dgvSelectAll_CellPainting;
        }

        private void ResetHeaderCheckBoxLocation(int columnIndex, int rowIndex)
        {
            //Get the column header cell bounds
            Columns[_checkBoxName].Width = 40;
            Rectangle oRectangle = GetCellDisplayRectangle(columnIndex, rowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - _headerCheckBox.Width) / 2;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - _headerCheckBox.Height) / 2;

            //Change the location of the CheckBox to make it stay on the header
            _headerCheckBox.Location = oPoint;

        }

        #endregion

        #endregion

        #region Protected

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            DisplayColumn();
        }

        public override void Sort(DataGridViewColumn dataGridViewColumn, ListSortDirection direction)
        {
            try
            {
                base.Sort(dataGridViewColumn, direction);
            }
            catch { }
        }


        #endregion

        #region Events

        private void MasterControl_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Rectangle rect = new Rectangle((_rowDefaultHeight - 16) / 2, (_rowDefaultHeight - 16) / 2, 16, 16);
            if (rect.Contains(e.Location))
            {
                if (_rowCurrent.Contains(e.RowIndex))
                {
                    _rowCurrent.Clear();
                    Rows[e.RowIndex].Height = _rowDefaultHeight;
                    Rows[e.RowIndex].DividerHeight = _rowDefaultDivider;
                }
                else
                {
                    if (_rowCurrent.Count != 0)
                    {
                        dynamic eRow = _rowCurrent[0];
                        _rowCurrent.Clear();
                        Rows[eRow].Height = _rowDefaultHeight;
                        Rows[eRow].DividerHeight = _rowDefaultDivider;
                        ClearSelection();
                        _collapseRow = true;
                        Rows[eRow].Selected = true;
                    }
                    _rowCurrent.Add(e.RowIndex);
                    Rows[e.RowIndex].Height = _rowExpandedHeight;
                    Rows[e.RowIndex].DividerHeight = _rowExpandedDivider;
                }
                ClearSelection();
                _collapseRow = true;
                Rows[e.RowIndex].Selected = true;
            }
            else
            {
                _collapseRow = false;
            }
        }

        private void MasterControl_Scroll(object sender, ScrollEventArgs e)
        {
            if (_rowCurrent.Count != 0)
            {
                _collapseRow = true;
                ClearSelection();
                Rows[_rowCurrent[0]].Selected = true;
            }
        }

        private void masterControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Columns.Contains(_checkBoxName))
                {
                    _ctmenu.Show(this, new Point(e.X, e.Y));
                }
            }
        }

        private void itemBochon_Click(object sender, EventArgs e)
        {
            CheckData(false);
        }

        private void itemchon_Click(object sender, EventArgs e)
        {
            CheckData(true);
        }

        #region CheckBox

        private void HeaderCheckBoxClick(CheckBox hCheckBox)
        {
            IsHeaderCheckBoxClicked1 = true;

            _checkRowIndex = null;
            _checkValue = null;
            foreach (DataGridViewRow row in Rows)
                ((DataGridViewCheckBoxCell)row.Cells[_checkBoxName]).Value = hCheckBox.Checked;

            RefreshEdit();

            _totalCheckedCheckBoxes = hCheckBox.Checked ? _totalCheckBoxes : 0;

            IsHeaderCheckBoxClicked1 = false;
            EventCheckBoxClick?.Invoke(-1, "ALL", hCheckBox.Checked);
        }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell rCheckBox)
        {
            if (rCheckBox != null)
            {
                //Modifiy Counter;            
                if ((bool)rCheckBox.Value && _totalCheckedCheckBoxes < _totalCheckBoxes)
                    _totalCheckedCheckBoxes++;
                else if (_totalCheckedCheckBoxes > 0)
                    _totalCheckedCheckBoxes--;

                //Change state of the header CheckBox.
                if (_totalCheckedCheckBoxes < _totalCheckBoxes)
                    _headerCheckBox.Checked = false;
                else if (_totalCheckedCheckBoxes == _totalCheckBoxes)
                    _headerCheckBox.Checked = true;

                EventCheckBoxClick?.Invoke(rCheckBox.RowIndex, Rows[rCheckBox.RowIndex].DataBoundItem, _totalCheckedCheckBoxes == 1);
            }
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void dgvSelectAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var columnIndex = Columns[_checkBoxName]?.Index;
            if (!IsHeaderCheckBoxClicked1 && e.ColumnIndex == columnIndex)
            {
                var check = (bool)((DataGridViewCheckBoxCell)this[(int)columnIndex, e.RowIndex]).Value;
                if (e.RowIndex != _checkRowIndex || check != _checkValue)
                    RowCheckBoxClick((DataGridViewCheckBoxCell)this[(int)columnIndex, e.RowIndex]);
                _checkRowIndex = e.RowIndex;
                _checkValue = check;
            }
        }

        private void dgvSelectAll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (CurrentCell is DataGridViewCheckBoxCell)
                CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvSelectAll_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (Columns.Contains(_checkBoxName))
            {
                if (e.RowIndex == -1 && e.ColumnIndex == Columns[_checkBoxName].Index)
                    ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
            }
        }

        #endregion

        #endregion

        #region Properties

        public List<GridMappingData> LstColumnMapping
        {
            get { return _lstColumnMapping; }
            set { _lstColumnMapping = value; }
        }

        public bool IsHeaderCheckBoxClicked1 { get { return _isHeaderCheckBoxClicked; } set { _isHeaderCheckBoxClicked = value; } }

        public bool IsShowCheckBox
        {
            get { return _isShowCheckBox; }
            set { _isShowCheckBox = value; }
        }
        public string ColumnUnique
        {
            get { return _columnUnique; }
            set { _columnUnique = value; }
        }
        #endregion
    }
}


