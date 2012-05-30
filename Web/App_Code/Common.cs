using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///Common 的摘要说明
/// </summary>
public class Common
{
    public Common()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static bool IsRole(int roles, int RoleSet)
    {
        return ((roles & RoleSet) == roles);
    }

    public static void CreateHeader(string strheader, Table table, int[] widths)
    {
        string[] Headers = strheader.Split(',');

        TableHeaderRow thr = new TableHeaderRow();

        int i = 0;
        if (Headers.Length != widths.Length)
        {
            i = -1;
        }
        foreach (string s in Headers)
        {
            TableHeaderCell tc = new TableHeaderCell();
            tc.Text = s;
            if (i > -1)
            {
                tc.Width = widths[i];
                i++;
            }
            thr.Cells.Add(tc);
        }
        table.Rows.Add(thr);
    }

}