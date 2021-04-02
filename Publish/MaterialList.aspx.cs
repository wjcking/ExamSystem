using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Web.UI.HtmlControls;

namespace Publish
{
    public partial class MaterialList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Bind();
        }
        private void Bind()
        {
            List<OutlineInfo> ol = EasyConfig.OutlineSys.GetListArray(" Type = 0 AND ID > 1");
            dgList.DataSource = ol;
            dgList.DataBind();
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            OutlineInfo o = new OutlineInfo();
            o.Content = txtContent.Text;
            o.Title = txtTitle.Text;
            o.Type = 0;
            o.PID = 1;
            o.ContentType = 0;

            if (string.IsNullOrEmpty(o.Title))
                return;

            if (string.IsNullOrEmpty(o.Content))
                return;

            EasyConfig.OutlineSys.Add(o);
            Response.Redirect(Request.Url.ToString());
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgList.Rows.Count; i++)
            {
                if (dgList.Rows[i] == null)
                    continue;

                HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[i].FindControl("hidIndex");
                TextBox txtTitle = (TextBox)dgList.Rows[i].FindControl("txtTitle");
                TextBox txtContent = (TextBox)dgList.Rows[i].FindControl("txtContent");

                TextBox txtContentType = (TextBox)dgList.Rows[i].FindControl("txtContentType");
                OutlineInfo o = new OutlineInfo();

                o.ID = Convert.ToInt32(hidIndex.Value);
                o.ContentType = Convert.ToInt32(txtContentType.Text);
                o.Content = txtContent.Text;
                o.PID = 1;
                o.Title = txtTitle.Text;
                o.Type = 0;

                EasyConfig.OutlineSys.Update(o);
            }

            Bind();
        }

        protected void dgList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            HtmlInputHidden hidIndex = (HtmlInputHidden)dgList.Rows[e.RowIndex].FindControl("hidIndex");
            int id = Convert.ToInt32(hidIndex.Value);
            EasyConfig.OutlineSys.Delete(id);
            Bind();
        }
    }
}