/***********************************************************************
 * Module:  EnumRight.cs
 * Author:  Administrator
 * Purpose: Definition of the Enum EnumRight
 ***********************************************************************/

using System;
namespace NameName.Model
{ public enum EnumRight 
{
    管理员 = (1 << 1),
    总经理 = (1 << 2),
    财务 = (1 << 3),
    采购 = (1 << 4),
    //门店 = (1 << 5)
}}
