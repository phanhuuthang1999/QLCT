using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyObject
{
    public static class UICommon
    {
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
    }
}
