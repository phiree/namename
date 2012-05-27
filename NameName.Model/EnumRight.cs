/***********************************************************************
 * Module:  EnumRight.cs
 * Author:  Administrator
 * Purpose: Definition of the Enum EnumRight
 ***********************************************************************/

using System;
namespace NameName.Model
{ public enum EnumRight : long
{
    管理员 = (1L << 1),
    总经理 = (1L << 2),
    财务 = (1L << 3),
    采购 = (1L << 4),
    门店 = (1L << 5)
}}
