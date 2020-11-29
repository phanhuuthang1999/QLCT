using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLCT_Server.Controls
{
    public static class CModule
    {
        #region "CustomGrid"

        //private Color backColor = UiCommon.ConvertHexToColor(UiCommon.LstHtConfig.FirstOrDefault(m => m.IDStyle == UiCommon.IDStyle && m.IDControl == (int)UiCommon.ControlMenuConfig.MenuButton && m.IDColumn == (int)UiCommon.ConfigColumn.Background)?.Value);
        //private backColorHover = UiCommon.ConvertHexToColor(UiCommon.LstHtConfig.FirstOrDefault(m => m.IDStyle == UiCommon.IDStyle && m.IDControl == (int)UiCommon.ControlMenuConfig.MenuButton && m.IDColumn == (int)UiCommon.ConfigColumn.BackgroundHover)?.Value);
        //private textColor = UiCommon.ConvertHexToColor(UiCommon.LstHtConfig.FirstOrDefault(m => m.IDStyle == UiCommon.IDStyle && m.IDControl == (int)UiCommon.ControlMenuConfig.MenuButton && m.IDColumn == (int)UiCommon.ConfigColumn.TextColor)?.Value);
        //private textColorHover = UiCommon.ConvertHexToColor(UiCommon.LstHtConfig.FirstOrDefault(m => m.IDStyle == UiCommon.IDStyle && m.IDControl == (int)UiCommon.ControlMenuConfig.MenuButton && m.IDColumn == (int)UiCommon.ConfigColumn.TextColorHover)?.Value);
        //private font = UiCommon.StringToFont(UiCommon.LstHtConfig.FirstOrDefault(m => m.IDStyle == UiCommon.IDStyle && m.IDControl == (int)UiCommon.ControlMenuConfig.MenuButton && m.IDColumn == (int)UiCommon.ConfigColumn.TextFont)?.Value);

        private static readonly DataGridViewCellStyle DateCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight };

        private static readonly DataGridViewCellStyle AmountCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = "N2"
        };

        // row header
        private static readonly DataGridViewCellStyle GridCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            BackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(79)), Convert.ToInt32(Convert.ToByte(129)), Convert.ToInt32(Convert.ToByte(189))),
            Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlLightLight,
            SelectionBackColor = SystemColors.Highlight,
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        // row
        private static readonly DataGridViewCellStyle GridCellStyle2 = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = SystemColors.ControlLightLight,
            Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlText,
            SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.False
        };

        //Cot dau tien NO
        private static readonly DataGridViewCellStyle GridCellStyle3 = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = Color.Lavender,
            Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.WindowText,
            SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        public static void ApplyGridTheme(DataGridView grid, bool isReadOnly = true)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.BackgroundColor = SystemColors.Window;
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.ColumnHeadersDefaultCellStyle = GridCellStyle;
            int height = 32;
            grid.ColumnHeadersHeight = height;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.DefaultCellStyle = GridCellStyle2;
            grid.RowTemplate.Resizable = DataGridViewTriState.True;
            height = 27;
            grid.RowTemplate.Height = height;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = SystemColors.GradientInactiveCaption;
            grid.ReadOnly = isReadOnly;
            grid.RowHeadersVisible = true;
            grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.RowHeadersDefaultCellStyle = GridCellStyle3;
            grid.ColumnHeadersDefaultCellStyle.Font = GridCellStyle.Font;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public static void SetGridRowHeader(DataGridView dgv, bool hSize = false)
        {
            dgv.TopLeftHeaderCell.Value = "*";
            dgv.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            foreach (DataGridViewColumn cCol in dgv.Columns)
            {
                if (cCol.ValueType.ToString() == typeof(DateTime).ToString())
                {
                    cCol.DefaultCellStyle = DateCellStyle;
                }
                else if (cCol.ValueType.ToString() == typeof(decimal).ToString() | cCol.ValueType.ToString() == typeof(double).ToString())
                {
                    cCol.DefaultCellStyle = AmountCellStyle;
                }
            }
            if (hSize)
            {
                dgv.RowHeadersWidth = dgv.RowHeadersWidth + 16;
            }
            dgv.AutoResizeColumns();
        }

        public static void RowPostPaint_HeaderCount(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //set rowheader count
            DataGridView grid = (DataGridView)sender;
            string rowIdx = (e.RowIndex + 1).ToString();
            dynamic centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height  /* - sender.rows(e.RowIndex).DividerHeight*/  );
            e.Graphics.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        #endregion
    }
}
