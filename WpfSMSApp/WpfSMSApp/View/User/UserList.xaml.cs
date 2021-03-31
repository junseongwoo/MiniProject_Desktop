﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfSMSApp.View.User
{
    /// <summary>
    /// MyAccount.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserList : Page
    {
        public UserList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                RdoAll.IsChecked = true;

            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 UserList Loded : {ex}");
                throw ex;
            }
        }

        private void BtnEditMyAccount_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new EditAccount());
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                NavigationService.Navigate(new AddUser());
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 BtnAddUsser_Click :{ex}");
                throw;
            }
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeactivateUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExportPdf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RdoAll_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Model.User> users = new List<Model.User>();

                if (RdoAll.IsChecked == true)
                {
                    users = Logic.DataAccess.GetUesrs();
                }

                this.DataContext = users;
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 : {ex}");
            }
        }

        private void RdoActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Model.User> users = new List<Model.User>();

                if (RdoActive.IsChecked == true)
                {
                    // user에서 활성화 된 사람만 보게하는것
                    users = Logic.DataAccess.GetUesrs().Where(u => u.UserActivated == true).ToList();
                    
                }

                this.DataContext = users;
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 : {ex}");
            }
        }

        private void RdoDeactive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Model.User> users = new List<Model.User>();

                if (RdoDeactive.IsChecked == true)
                {
                    users = Logic.DataAccess.GetUesrs().Where(u => u.UserActivated == false).ToList();
                }

                this.DataContext = users;
            }
            catch (Exception ex)
            {
                Commons.LOGGER.Error($"예외발생 : {ex}");
            }
        }
    }
}