﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IPAM_NOTE.UserPages
{
    /// <summary>
    /// About.xaml 的交互逻辑
    /// </summary>
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void GithubDownloadButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(DataBrige.DownloadUrl);
        }

        private void LanzouDownloadButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("点击确定，将打开蓝奏云下载链接,提取密码为ab7k", "蓝奏云下载", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                Process.Start("https://wwt.lanzout.com/b00sfauuj");
            }

        }


        /// <summary>
        /// 版本对比
        /// </summary>
        private void VerCheck()
        {
            NowVer.Text = "版本号：V" + Convert.ToString(DataBrige.Ver) + "-Beta";


            if (Convert.ToDouble(DataBrige.LatestVersion) > Convert.ToDouble(DataBrige.Ver))
            {
                NewVerPlan.Visibility = Visibility.Visible;
                NewVer.Text = "最新版：V" + Convert.ToString(DataBrige.LatestVersion) + "-Beta";
                NewVer.Foreground = Brushes.DarkOrange;

               
            }
            else
            {
                NewVerPlan.Visibility = Visibility.Collapsed;
            }

            //见鬼的疑惑操作
            string updateInfo="";

            if (DataBrige.UpdateInfos != "0")
            {
                updateInfo = "V" + DataBrige.LatestVersion + "-Beta更新内容";

            }

            if (updateInfo != "V0-Beta更新内容" && updateInfo !="")
            {
                UpdateBlock.Text = updateInfo;
                UpdateInfo.Text = DataBrige.UpdateInfos;
            }

            


        }


        private void NowVer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DataBrige.DownloadUrl != "")
            {
                Process.Start(DataBrige.DownloadUrl);
            }


        }




        private void IpamNote_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://github.com/yaobus/IPAM-NOTE.git");
        }

        private void About_OnLoaded(object sender, RoutedEventArgs e)
        {
            VerCheck();	//版本检查
        }
    }
}
