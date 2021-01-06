using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AdminDTO
    {
        /// <summary>
        /// iDus là id được liên kết khóa ngoại với id trong account để phân biệt các account với nhau
        /// iDaddmin là id của addmin để phân biệt các addmin trong cùng bảng
        /// </summary>
        private int iDus;
        private int iDadmin;
        private string HoTen;
        private string NgaySinh;
        private string UserName;

        //--------------------------------------------------------------------------------//
        public int IDadmin { get => iDadmin; set => iDadmin = value; }
        public int IDus { get => iDus; set => iDus = value; }

        public string Hoten{ get => HoTen; set => HoTen = value; }
        public string Ngaysinh { get => NgaySinh; set => NgaySinh = value; }
        public string Username { get => UserName; set => UserName = value; }


    }
}
