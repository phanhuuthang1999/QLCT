﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyObject
{
    public static class Instance
    {
        public static int Port = 9999;

        public static string IPServer = "localhost";
        public static string objURI = "PRIME_URI";
        public static string TcpChannelName = "Exam1";

        #region Title

        public static string TitleServer = "QUẢN LÝ CHẤM THI";
        public static string TitleClient = "THI CUỐI KỲ NHẬP MÔN LẬP TRÌNH";

        public static string NewSite = "Add New Site";
        public static string EditSite = "Edit Site";
        public static string CoppySite = "Coppy Site";

        public static string TitleBoCauHoi = "QUẢN LÝ BỘ CÂU HỎI";

        public static string TitleAddCauHoi = "THÊM BỘ CÂU HỎI";
        public static string TitleCoppyCauHoi = "SAO CHÉP BỘ CÂU HỎI";
        public static string TitleEditCauHoi = "SỬA BỘ CÂU HỎI";
        #endregion


    }
}
