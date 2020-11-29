using DataLayer.BLL;
using ProxyObject;
using QLCT_Server.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCT_Server.HeThong
{
    public partial class frmBoCauHoi : Form
    {
        #region Variable

        private UcDataGridView gridData;
        private CauHoiBll _bus;

        #endregion

        #region Constructor

        public frmBoCauHoi()
        {
            InitializeComponent();
            this.FormClosing += FrmMain_FormClosing;

            gridData = new UcDataGridView();
            _bus = new CauHoiBll();

            gridData.ColumnUnique = "Id";
            gridData.IsShowCheckBox = true;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tableLayoutPanel1.Controls.Add(gridData, 0, 2);
            tableLayoutPanel1.SetColumnSpan(gridData, 5);


            gridData.LstColumnMapping.Add(new GridMappingData { Id = 1, Name = "MAMONAN", HeaderText = "Ma món ăn", Align = DataGridViewContentAlignment.MiddleCenter });
            gridData.LstColumnMapping.Add(new GridMappingData { Id = 2, Name = "TenMonAnNew", HeaderText = "Tên món ăn" });
            gridData.LstColumnMapping.Add(new GridMappingData { Id = 3, Name = "DONGIA", HeaderText = "Đơn giá", Align = DataGridViewContentAlignment.MiddleCenter });

        }

        #endregion

        #region Private

        private void LoadGrid()
        {
            gridData.DataSource = _bus.GetAllQuestion(txtTimKiem.Text);
        }

        #endregion

        #region Events

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UICommon.ShowMsgQuestionString("Bạn có chắc muốn thoát") != DialogResult.Yes)
            {
                e.Cancel = true;
            }

        }

        #endregion
    }
}
