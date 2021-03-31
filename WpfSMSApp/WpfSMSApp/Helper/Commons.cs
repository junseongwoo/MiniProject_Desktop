﻿using NLog;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using WpfSMSApp.Model;

namespace WpfSMSApp
{
    public class Commons
    {
        // NLog 정적 인스턴스 생성
        public static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        // 로그인한 유저 정보
        public static User LOGINED_USER;

        /// <summary>
        /// md5 암호화처리 매서드
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="plainStr"></param>
        /// <returns></returns>
        public static string GetMd5Hash(MD5 md5Hash, string plainStr)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(plainStr));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }


        /// <summary>
        /// C# 이메일 정규식 처리 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
        }
    }
}
