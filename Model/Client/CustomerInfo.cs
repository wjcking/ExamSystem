using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class CustomerInfo
    {

        public CustomerInfo()
        {

        }
        private string _address = "";
        private string _birthday = "";
        private string _cellphone = "";
        private string _city = "";
        private string _customername = " ";
        private int _dealtime = 0;
        private string _email = "";
        private int _freeze = 0;
        private string _gender = "男";
        private int _id = -1;
        private string _idcard = "";
        private string _intro = "";
        private string _job = "";
        private string _lastlogin = "";
        private string _level = "";
        private int _logintime = 0;
        private string _machineid = "";
        private string _nickname = "";
        private string _password = "";
        private string _phone = "";
        private int _producttotal = 0;
        private string _province = "";
        private string _qq = "";
        private string _registertime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        /// <summary>
        /// 
        /// </summary>

        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Cellphone
        {
            set { _cellphone = value; }
            get { return _cellphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Dealtime
        {
            set { _dealtime = value; }
            get { return _dealtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Freeze
        {
            set { _freeze = value; }
            get { return _freeze; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Idcard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Intro
        {
            set { _intro = value; }
            get { return _intro; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Job
        {
            set { _job = value; }
            get { return _job; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLogin
        {
            set { _lastlogin = value; }
            get { return _lastlogin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Level
        {
            set { _level = value; }
            get { return _level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LoginTime
        {
            set { _logintime = value; }
            get { return _logintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Machineid
        {
            set { _machineid = value; }
            get { return _machineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nickname
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProductTotal
        {
            set { _producttotal = value; }
            get { return _producttotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
      
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegisterTime
        {
            set { _registertime = value; }
            get { return _registertime; }
        }

        public string Area { get; set; }
    }
}
