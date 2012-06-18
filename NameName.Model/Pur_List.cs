/***********************************************************************
 * Module:  Shop_AskList.cs
 * Author:  Administrator
 * Purpose: Definition of the Class Shop_AskList
 ***********************************************************************/

using System;
namespace NameName.Model
{
    public class Pur_List
    {
        /// <summary>
        /// 格式化流水号,由sys_formatSerialNo生成
        /// </summary>
        public virtual string PurBillNo{get;set;}
        /// <summary>
        /// 采购员
        /// </summary>
        public virtual UserInfo PurUser{get;set;}
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CrtDate{get;set;}
        /// <summary>
        /// 审核人员
        /// </summary>
        public virtual UserInfo ChkUser{get;set;}
       /// <summary>
       /// 审核时间
       /// </summary>
        public virtual DateTime? ChkDate{get;set;}
        /// <summary>
        /// 采购单状态:1 待审核 2 审核 3 报销配货
        /// </summary>
        public virtual int State{get;set;}
        /// <summary>
        /// 采购单所在区域
        /// </summary>
        public virtual AreaInfo AreaInfo { get; set; }

    }
}