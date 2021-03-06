﻿using BEDA.CIB.Contracts.Responses;
using BEDA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BEDA.CIB.Contracts.Requests
{
    /// <summary>
    /// 3.3.7交易流水分页查询请求（返回包含虚拟子账户交易信息）请求主体
    /// </summary>
    public class V1_BALNTRADEINQUIRYTRNRQ : IRequest<V1_BALNTRADEINQUIRYTRNRS>
    {
        /// <summary>
        /// 3.3.7交易流水分页查询请求（返回包含虚拟子账户交易信息）
        /// </summary>
        public BALNTRADEINQUIRYTRNRQ BALNTRADEINQUIRYTRNRQ { get; set; }
    }
    /// <summary>
    /// 3.3.7交易流水分页查询请求（返回包含虚拟子账户交易信息）
    /// </summary>
    public class BALNTRADEINQUIRYTRNRQ : BIZRQBASE
    {
        /// <summary>
        /// 在响应报文中包含该内容 ，非必输
        /// </summary>
        [XmlElement(Order = 1)]
        public string CLTCOOKIE { get; set; }
        /// <summary>
        /// 3.3.7查询主体
        /// </summary>
        [XmlElement(Order = 2)]
        public BALNTRADEINQUIRYTRN_RQBODY RQBODY { get; set; }
    }
    /// <summary>
    /// 3.3.7交易流水分页查询请求（返回包含虚拟子账户交易信息）
    /// </summary>
    public class BALNTRADEINQUIRYTRN_RQBODY
    {
        /// <summary>
        /// 付款人账户，必输
        /// </summary>
        [XmlElement(Order = 0)]
        public ACCTFROM ACCTFROM { get; set; }
        /// <summary>
        /// 包含交易流水（未指定起止时间，表示查余额；若指定起止时间，那么：1）开始时间=结束时间；2）开始时间早于结束时间，并且结束时间不为当天。。建议查询指定某一天的流水，避免网络传输带来的超时）
        /// </summary>
        [XmlElement(Order = 1)]
        public INCTRAN INCTRAN { get; set; }
    }
    /// <summary>
    /// 包含交易流水，非必输（未指定起止时间，表示查余额；若指定起止时间，那么：1）开始时间=结束时间；2）开始时间早于结束时间，并且结束时间不为当天。。建议查询指定某一天的流水，避免网络传输带来的超时）
    /// </summary>
    public class INCTRAN
    {
        /// <summary>
        /// 开始时间 格式：yyyy-MM-dd(必输)
        /// </summary>
        [XmlIgnore]
        public DateTime? DTSTART { get; set; }
        /// <summary>
        /// 开始时间 格式：yyyy-MM-dd ,对应<see cref="DTSTART"/>	必输
        /// </summary>
        [XmlElement("DTSTART", Order = 0)]
        public string DTSTARTStr
        {
            get
            {
                return this.DTSTART?.ToString("yyyy-MM-dd");
            }
            set
            {
                this.DTSTART = value.TryConvert<DateTime>();
            }
        }
        /// <summary>
        /// 结束时间 格式：yyyy-MM-dd(必输)
        /// </summary>
        [XmlIgnore]
        public DateTime? DTEND { get; set; }
        /// <summary>
        /// 结束时间 格式：yyyy-MM-dd ,对应<see cref="DTEND"/>	必输
        /// </summary>
        [XmlElement("DTEND", Order = 1)]
        public string DTENDStr
        {
            get
            {
                return this.DTEND?.ToString("yyyy-MM-dd");
            }
            set
            {
                this.DTEND = value.TryConvert<DateTime>();
            }
        }
        /// <summary>
        /// 请求响应的页数（代表从第几页开始查询）（必输）
        /// </summary>
        [XmlElement(Order = 2)]
        public int PAGE { get; set; } = 1;
        /// <summary>
        /// 借贷标记：0表示借方(往帐)  1表示贷方(来帐)  默认查询2-借贷双方全部流水
        /// </summary>
        [XmlElement(Order = 3)]
        public int TRNTYPE { get; set; } = 2;
    }
}
