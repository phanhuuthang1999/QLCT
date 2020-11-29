using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Common
{
    public static class UICommon
    {
        public enum ModeForm { ThemMoi, CapNhat, SaoChep, Xem };

        public static string GetDescription(this Enum val)
        {
            string name = Enum.GetName(val.GetType(), val);

            System.Reflection.FieldInfo obj = val.GetType().GetField(name);

            if (obj != null)
            {
                object[] attributes = obj.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

                return attributes.Length > 0 ? ((System.ComponentModel.DescriptionAttribute)attributes[0]).Description : null;
            }

            return null;
        }

        #region Show Msg

        public static DialogResult ShowMsgInfoString(string pMessageText, params string[] pParameter)
        {
            try
            {
                pMessageText = string.Format(pMessageText, pParameter);

                return MessageBox.Show(pMessageText, "Thông tin!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //ManageException(ex);
            }

            return DialogResult.None;
        }

        public static DialogResult ShowMsgWarningString(string pMessageText, params string[] pParameter)
        {
            try
            {
                pMessageText = string.Format(pMessageText, pParameter);

                return MessageBox.Show(pMessageText, "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
               // ManageException(ex);
            }

            return DialogResult.None;
        }

        public static DialogResult ShowMsgQuestionString(string pMessageText, params string[] pParameter)
        {
            try
            {
                pMessageText = string.Format(pMessageText, pParameter);

                return MessageBox.Show(pMessageText, "Thông báo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                //ManageException(ex);
            }

            return DialogResult.None;
        }

        public static DialogResult ShowMsgQuestionString(string pMessageText, MessageBoxButtons pMsgButton, params string[] pParameter)
        {
            try
            {
                pMessageText = string.Format(pMessageText, pParameter);

                return MessageBox.Show(pMessageText, "Thông báo?", pMsgButton, MessageBoxIcon.Question);
            }
            catch (Exception ex)
            {
                //ManageException(ex);
            }

            return DialogResult.None;
        }

        public static DialogResult ShowMsgErrorString(string pMessageText, params string[] pParameter)
        {
            try
            {
                pMessageText = string.Format(pMessageText, pParameter);

                return MessageBox.Show(pMessageText, "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //ManageException(ex);
            }

            return DialogResult.None;
        }

        #endregion

        #region ConvertObject

        public static object CloneObject(object cloner)
        {
            object newObject = Activator.CreateInstance(cloner.GetType());

            PropertyInfo[] pros = cloner.GetType().GetProperties();
            foreach (PropertyInfo pro in pros)
            {
                PropertyInfo p = newObject.GetType().GetProperty(pro.Name);
                if (p != null && p.CanWrite && pro.CanRead)
                {
                    p.SetValue(newObject, pro.GetValue(cloner, null), null);
                }
            }
            return newObject;
        }

        public static object CloneObject(object cloner, object newObject)
        {
            PropertyInfo[] pros = cloner.GetType().GetProperties();
            foreach (PropertyInfo pro in pros)
            {
                PropertyInfo p = newObject.GetType().GetProperty(pro.Name);
                if (p != null && p.CanWrite && pro.CanRead)
                {
                    p.SetValue(newObject, pro.GetValue(cloner, null), null);
                }
            }
            return newObject;
        }

        public static object CloneObject(object cloner, object newObject, params string[] prosNonClone)
        {
            PropertyInfo[] pros = cloner.GetType().GetProperties();
            foreach (PropertyInfo pro in pros)
            {
                if (prosNonClone.Length > 0 && prosNonClone.Contains(pro.Name))
                {
                    continue;
                }

                PropertyInfo p = newObject.GetType().GetProperty(pro.Name);
                if (p != null && p.CanWrite && pro.CanRead)
                {
                    p.SetValue(newObject, pro.GetValue(cloner, null), null);
                }
            }
            return newObject;
        }

        //public static string ConvertRftToText(string rtf, bool isDisplay = false)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(rtf)) return "";
        //        var richTextBox = new System.Windows.Forms.RichTextBox();
        //        richTextBox.Rtf = rtf;
        //        var text = richTextBox.Text.Replace("  ", " ");
        //        if (isDisplay)
        //        {
        //            if (text.Length == 0)
        //                return "<rỗng>";
        //            else
        //            {
        //                //giới hạn lấy 50 kí tự
        //                if (text.Length > 50)
        //                    return text.Substring(0, 49) + "...";
        //                else
        //                    return text;
        //            }
        //        }
        //        else
        //        {
        //            return text;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}

        //public static string ConvertTextToRtf(string text, System.Drawing.Color color, System.Drawing.Font font = null)
        //{
        //    var richTextBox = new System.Windows.Forms.RichTextBox();
        //    richTextBox.Text = text;
        //    richTextBox.SelectAll();
        //    if (color != null)
        //        richTextBox.SelectionColor = color;
        //    if (font != null)
        //        richTextBox.SelectionFont = font;
        //    return richTextBox.SelectedRtf;
        //}

        //public static int GetLengthRtf(string rtf)
        //{
        //    var richTextBox = new RichTextBox();
        //    richTextBox.Rtf = rtf;
        //    return richTextBox.TextLength;
        //}

        #endregion
    }
}
