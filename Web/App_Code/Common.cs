using System;
using System.Collections.Generic;

using System.Web;

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

    public static bool IsRole(long roles, long RoleSet)
    {
        return ((roles & RoleSet) == roles);
    }

}