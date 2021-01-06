using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiaoVienDTO
    {
        /// <summary>
        /// idGV là id của giáo viên để phân biệt các giáo viên với nhau
        /// idus là id liên kết khóa ngoại với id trong bảng account để phân biệt account
        /// </summary>
        private int idGV;
        private string tenGV;
        private int idus;

        //-----------------------------------------------------------------------------//
        public int IdGV { get => idGV; set => idGV = value; }
        public string TenGV { get => tenGV; set => tenGV = value; }
        public int Idus { get => idus; set => idus = value; }
    }
}
