﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SES.CMS
{
    class NumberToStringVN
    {
        private static string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
        private static string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };

        //Hàm kiểm tra số lẻ/chẵn
        public static bool KiemTraSoLe(decimal soTienCheck)
        {
            string strSoTien = soTienCheck.ToString();
            string[] num = strSoTien.Split('.');
            if (num.Length == 1)
                return false;
            if (num.Length == 2 && Convert.ToInt32(num[1]) == 0)
                return false;
            return true;
        }

        // Hàm đọc số thành chữ
        public static string DocTienBangChu(decimal SoTien, string strTail)
        {
            int lan, i;
            decimal so;
            string result = "";
            string KetQua = "", tmp = "";
            bool booAm = false;
            int[] ViTri = new int[6];

            if (SoTien < 0)
            {
                SoTien = -SoTien;
                booAm = true;
            }
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
                so = SoTien;
            else
                so = -SoTien;

            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "Số tiền quá lớn";
            }

            if (KiemTraSoLe(SoTien) == false)
            {
                ViTri[5] = (int)(so / 1000000000000000);
                so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
                ViTri[4] = (int)(so / 1000000000000);
                so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
                ViTri[3] = (int)(so / 1000000000);
                so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
                ViTri[2] = (int)(so / 1000000);
                ViTri[1] = (int)((so % 1000000) / 1000);
                ViTri[0] = (int)(so % 1000);

                if (ViTri[5] > 0)
                    lan = 5;
                else if (ViTri[4] > 0)
                    lan = 4;
                else if (ViTri[3] > 0)
                    lan = 3;
                else if (ViTri[2] > 0)
                    lan = 2;
                else if (ViTri[1] > 0)
                    lan = 1;
                else
                    lan = 0;

                for (i = lan; i >= 0; i--)
                {
                    tmp = DocSo3ChuSo(ViTri[i]);
                    KetQua += tmp;
                    if (ViTri[i] != 0) KetQua += Tien[i];
                }

                if (KetQua.Substring(KetQua.Length - 1, 1) == ",")
                    KetQua = KetQua.Substring(0, KetQua.Length - 1);

                KetQua = KetQua.Trim() + strTail;

                if (booAm)
                    KetQua = "Âm " + KetQua.Trim() + strTail;

                result += KetQua.Substring(0, 1).ToLower() + KetQua.Substring(1);
                return result.Substring(0, 1).ToUpper() + result.Substring(1);
            }
            else
            {
                ViTri[5] = (int)(so / 1000000000000000);
                so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
                ViTri[4] = (int)(so / 1000000000000);
                so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
                ViTri[3] = (int)(so / 1000000000);
                so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
                ViTri[2] = (int)(so / 1000000);
                ViTri[1] = (int)((so % 1000000) / 1000);
                ViTri[0] = (int)(so % 1000);

                if (ViTri[5] > 0)
                    lan = 5;
                else if (ViTri[4] > 0)
                    lan = 4;
                else if (ViTri[3] > 0)
                    lan = 3;
                else if (ViTri[2] > 0)
                    lan = 2;
                else if (ViTri[1] > 0)
                    lan = 1;
                else
                    lan = 0;

                for (i = lan; i >= 0; i--)
                {
                    tmp = DocSo3ChuSo(ViTri[i]);
                    KetQua += tmp;
                    if (ViTri[i] != 0) KetQua += Tien[i];
                }

                if (KetQua.Substring(KetQua.Length - 1, 1) == ",")
                    KetQua = KetQua.Substring(0, KetQua.Length - 1);

                KetQua = KetQua.Trim();

                if (booAm)
                    KetQua = "Âm " + KetQua.Trim() + strTail;

                string[] num = SoTien.ToString().Split('.');
                result += KetQua.Trim() + " lẻ " + DocTienBangChu(Convert.ToDecimal(num[1]), " đồng");
                return result.Substring(0, 1).ToUpper() + result.Substring(1);
            }
        }

        // Hàm đọc số có 3 chữ số
        private static string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;

            if ((tram == 0) && (chuc == 0) && (donvi == 0))
                return "";

            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }

            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }

            if (chuc == 1)
                KetQua += " mười";

            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }
    }
}
