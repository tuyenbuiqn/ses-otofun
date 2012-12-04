using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SES.CMS
{
    public class ShoppingCart
    {
        //Lam thu gio hang voi datatable
        DataTable tbCart = new DataTable();

        public ShoppingCart()
        {
            tbCart.Columns.Add("STT");
            tbCart.Columns.Add("DichVuID");
            tbCart.Columns.Add("SoLuong");
            tbCart.Columns.Add("ThanhTien");
            tbCart.Columns.Add("MoPhanID");
            tbCart.Columns.Add("DonGia");
            tbCart.Columns.Add("NgayYeuCauThucHien");
        }

        public DataTable getTable()
        {
            return this.tbCart;
        }
        public void setTable(DataTable tbCart)
        {
            this.tbCart = tbCart;
        }

        public DataTable initCart(int dichVuID, int soLuong, long thanhTien, int moPhanID, Int64 donGia,DateTime ngayYeuCauThucHien)
        {
            DataRow row = tbCart.NewRow();
            row[0] = 1;
            row[1] = dichVuID;
            row[2] = soLuong;
            row[3] = thanhTien;
            row[4] = moPhanID;
            row[5] = donGia;
            row[6] = ngayYeuCauThucHien;
            tbCart.Rows.Add(row);
            return tbCart;
        }

        // Them san pham 
        public DataTable addProduct(int dichVuID, int soLuong, long thanhTien,int moPhanID, Int64 donGia,DateTime ngayYeuCauThucHien)
        {
            DataRow row = tbCart.NewRow();
            row[0] = tbCart.Rows.Count + 1;
            row[1] = dichVuID;
            row[2] = soLuong;
            row[3] = thanhTien;
            row[4] = moPhanID;
            row[5] = donGia;
            row[6] = ngayYeuCauThucHien;
            tbCart.Rows.Add(row);
            return tbCart;
        }

        public DataTable deleteCart(DataTable tbDelete, int dichVuID, int moPhanID)
        {
            DataTable tbDel = tbDelete;
            foreach (DataRow row in tbDel.Rows)
            {
                if (int.Parse(row[1].ToString()) == dichVuID && int.Parse(row[4].ToString())==moPhanID)
                {
                    tbDel.Rows.Remove(row);
                    break;
                }
            }
            return tbDel;
        }

        public DataTable DeleteCartItem(DataTable tbDelete, int STT)
        {

            DataTable dtDel = tbDelete;
            
            //dtDel.Rows.RemoveAt(STT);
            //dtDel.AcceptChanges();
           
            //return dtDel;

            for (int i = 0; i < dtDel.Rows.Count; i++)
            {
                if (int.Parse(dtDel.Rows[i]["STT"].ToString()) == STT)
                {
                    dtDel.Rows[i].Delete();
                    break;
                }
            }
            return dtDel;

        }
       

        public DataTable updateCart(DataTable dtUpdate, int dichVuID, int soLuong, Int64 donGia, int moPhanID)
        {
            DataTable tb = dtUpdate;
            foreach (DataRow row in tb.Rows)
            {
                if (int.Parse(row[1].ToString()) == dichVuID && int.Parse(row[4].ToString())==moPhanID)
                {
                    row[2] = int.Parse(row[2].ToString()) + soLuong;
                    row[3] = donGia * int.Parse(row[2].ToString());
                }
              
            }
            return tb;
        }

        public DataTable updateSL(DataTable tbUpdate, int STT, int soLuong, long thanhTien)
        {
            DataTable tbUpdateSL = tbUpdate;
            foreach (DataRow row in tbUpdateSL.Rows)
            {
                if (int.Parse(row[0].ToString()) == STT)
                {
                    row[2] = soLuong;
                    row[3] = thanhTien;
                }
            }
            return tbUpdateSL;
        }
    }
}
