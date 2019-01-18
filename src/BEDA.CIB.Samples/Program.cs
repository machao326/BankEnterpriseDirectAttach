﻿using BEDA.CIB.Contracts;
using BEDA.CIB.Contracts.Requests;
using BEDA.CIB.Contracts.Responses;
using System;
using System.Collections.Generic;

namespace BEDA.CIB.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 3.2	登录消息
            //LoginSample();
            #endregion

            #region 3.3	账户查询
            //CURRACCTQUERYTRNRQSample();
            //TIMEQUERYTRNRQSimple();
            //TIMEDEPOSITQUERYTRNRQSample();
            //DEMANDDEPOSITQUERYTRNRQSample();
            //ACCOUNTQUERYTRNRQSample();
            //SCUSTSTMTTRNRQSample();
            //BALNTRADEINQUIRYTRNRQSample();
            //FIRMTIMEQUERYTRNRQSample();
            //FSTMTTRNRQSample();
            //TRADEOVERVIEWTRNRQSample();
            #endregion

            #region 3.4	企业财务室
            //XFERTRNRQSample();
            //XFERINQTRNRQSample();
            //RPAYOFFTRNRQSample();
            //RPAYOFFINQTRNRQSample();
            //GATHERTRNRQSample();
            //FBBATCHGATHERTRNRQSample();
            //FBBATCHSTMTTRNRQSample();
            //RBATCHTRSFRTRNRQSample();
            //RECEIPTTRNRQSample();
            //ICTRANSFERTRNRQSample();
            //ICTRANSFERINQTRNRQSample();
            //ASYNBATCHTRSFRTRNRQSample();
            #endregion

            #region 3.7	集团服务
            //XPMTTRNRQSimple();
            CMSTMTQUERYTRNRQSimple();
            #endregion

            Console.ReadLine();
        }

        #region 基础数据
        const long cid = 1100343164;
        const string uid = "qw1";
        const string pwd = "a1111111";//密码错误6次账号会被永久锁定无法解锁
        static ICIBClient client = new CIBClient("127.0.0.1", 8007);

        const string mainAccountId = "117010100100000177";
        const string mainAccountName = "中国民族证券有限责任公司12";
        const string financeInnerAccountId = "111333";

        public static T GetRequest<T>()
            where T : FOXRQ, new()
        {
            return new T
            {
                SIGNONMSGSRQV1 = new SIGNONMSGSRQV1
                {
                    SONRQ = new SONRQ
                    {
                        CID = cid,
                        USERID = uid,
                        USERPASS = pwd,
                    }
                }
            };
        }
        #endregion

        #region 3.2	登录消息
        /// <summary>
        /// 3.2	登录消息
        /// </summary>
        public static void LoginSample()
        {
            var rq = GetRequest<FOXRQ>();
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        #endregion

        #region 3.3	账户查询
        /// <summary>
        /// 3.3.1	活期账户信息查询
        /// </summary>
        public static void CURRACCTQUERYTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.1", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_CURRACCTQUERYTRNRQ, V1_CURRACCTQUERYTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_CURRACCTQUERYTRNRQ
            {
                CURRACCTQUERYTRNRQ = new CURRACCTQUERYTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new RQACCT
                    {
                        ACCTID = mainAccountId
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.3.2	定期账户查询
        /// </summary>
        public static void TIMEQUERYTRNRQSimple()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.2", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_TIMEQUERYTRNRQ, V1_TIMEQUERYTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_TIMEQUERYTRNRQ
            {
                TIMEQUERYTRNRQ = new TIMEQUERYTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new PAGED_RQACCT
                    {
                        ACCTID = mainAccountId,
                        PAGE = 1
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.3.3	定期存款信息查询
        /// </summary>
        public static void TIMEDEPOSITQUERYTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.3", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_TIMEDEPOSITQUERYTRNRQ, V1_TIMEDEPOSITQUERYTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_TIMEDEPOSITQUERYTRNRQ
            {
                TIMEDEPOSITQUERYTRNRQ = new TIMEDEPOSITQUERYTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new RQACCT
                    {
                        ACCTID = mainAccountId
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.3.4	非定期存款信息查询
        /// </summary>
        public static void DEMANDDEPOSITQUERYTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.4", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_DEMANDDEPOSITQUERYTRNRQ, V1_DEMANDDEPOSITQUERYTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_DEMANDDEPOSITQUERYTRNRQ
            {
                DEMANDDEPOSITQUERYTRNRQ = new DEMANDDEPOSITQUERYTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new RQACCT
                    {
                        ACCTID = mainAccountId
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.3.5	账户信息查询
        /// </summary>
        public static void ACCOUNTQUERYTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.5", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_ACCOUNTQUERYTRNRQ, V1_ACCOUNTQUERYTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_ACCOUNTQUERYTRNRQ
            {
                ACCOUNTQUERYTRNRQ = new ACCOUNTQUERYTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new RQACCT
                    {
                        ACCTID = mainAccountId
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.3.6	账户余额和交易流水分页查询
        /// </summary>
        public static void SCUSTSTMTTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.6", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_SCUSTSTMTTRNRQ, V1_SCUSTSTMTTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_SCUSTSTMTTRNRQ
            {
                SCUSTSTMTTRNRQ = new SCUSTSTMTTRNRQ
                {
                    TRNUID = tid,
                    CLTCOOKIE = "123",
                    SCUSTSTMTRQ = new SCUSTSTMTTRNRQ_SCUSTSTMTRQ
                    {
                        VERSION = "2.0",
                        ACCTFROM = new ACCTFROM
                        {
                            ACCTID = mainAccountId
                        },
                        INCTRAN = new INCTRAN
                        {
                            DTEND = DateTime.Now,
                            DTSTART = DateTime.Now,
                            TRNTYPE = 2,
                        },
                        SELTYPE = 1
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.3.7	账号余额和交易流水分页查询（返回增加虚拟子账户交易信息）
        /// </summary>
        public static void BALNTRADEINQUIRYTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.7", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_BALNTRADEINQUIRYTRNRQ, V1_BALNTRADEINQUIRYTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_BALNTRADEINQUIRYTRNRQ
            {
                BALNTRADEINQUIRYTRNRQ = new BALNTRADEINQUIRYTRNRQ
                {
                    TRNUID = tid,
                    CLTCOOKIE = "123",
                    RQBODY = new BALNTRADEIN_RQBODY
                    {
                        ACCTFROM = new ACCTFROM
                        {
                            ACCTID = mainAccountId
                        },
                        INCTRAN = new INCTRAN
                        {
                            DTEND = DateTime.Now.AddDays(-1),
                            DTSTART = DateTime.Now.AddDays(-1),
                            TRNTYPE = 2,
                        },
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.3.8	单位定期一本通账户查询
        /// </summary>
        public static void FIRMTIMEQUERYTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.8", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_FIRMTIMEQUERYTRNRQ, V1_FIRMTIMEQUERYTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_FIRMTIMEQUERYTRNRQ
            {
                FIRMTIMEQUERYTRNRQ = new FIRMTIMEQUERYTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new PAGED_RQACCT
                    {
                        ACCTID = mainAccountId
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.3.9	账户交易流水文件查询
        /// </summary>
        public static void FSTMTTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.9", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_FSTMTTRNRQ, V1_FSTMTTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_FSTMTTRNRQ
            {
                FSTMTTRNRQ = new FSTMTTRNRQ
                {
                    TRNUID = tid,
                    CLTCOOKIE = "123",
                    SCUSTSTMTRQ = new FSTMTTRNRQ_SCUSTSTMTRQ
                    {
                        ACCTFROM = new ACCTFROM
                        {
                            ACCTID = mainAccountId
                        },
                        INCTRAN = new FSTMTTRNRQ_INCTRAN
                        {
                            DTEND = DateTime.Now.AddDays(-1),
                            DTSTART = DateTime.Now.AddDays(-1),
                            TRNTYPE = 2,
                            NUM = 100
                        },
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
            var list = rs.SECURITIES_MSGSRSV1.FSTMTTRNRS.SCUSTSTMTRS.TRANLIST.GetDetails();
        }
        /// <summary>
        /// 3.3.10	交易概览
        /// </summary>
        public static void TRADEOVERVIEWTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.3.10", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_TRADEOVERVIEWTRNRQ, V1_TRADEOVERVIEWTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_TRADEOVERVIEWTRNRQ
            {
                TRADEOVERVIEWTRNRQ = new TRADEOVERVIEWTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new TRADEOVERVIEWTRN_RQBODY
                    {
                        QUERYDATE = DateTime.Now.AddDays(-2)
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        #endregion

        #region 3.4	企业财务室
        /// <summary>
        /// 3.4.1	转账汇款指令提交
        /// </summary>
        public static void XFERTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.1", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_XFERTRNRQ, V1_XFERTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_XFERTRNRQ
            {
                XFERTRNRQ = new XFERTRNRQ
                {
                    TRNUID = tid,
                    CLTCOOKIE = "123",
                    XFERRQ = new XFERRQ
                    {
                        XFERINFO = new XFERINFO
                        {
                            ACCTFROM = new ACCTFROM
                            {
                                ACCTID = mainAccountId,
                                NAME = mainAccountName
                            },
                            ACCTTO = GetACCTTO(3),
                            PURPOSE = "转账",
                            TRNAMT = 1.77m,
                        }
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 获取转账账号 
        /// 0 普通转账、对公收款账号(行内)
        /// 1 兴业银行对私收款账号（行内）
        /// 2 普通转账、对公收款账号(跨行)
        /// 3 普通转账、对私收款账号(跨行)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static ACCTTO GetACCTTO(byte type)
        {
            switch (type)
            {
                case 0://普通转账、对公收款账号(行内)
                    return new ACCTTO
                    {
                        ACCTID = "117010100100107091",
                        INTERBANK = "Y",
                        LOCAL = "Y",
                        NAME = "test",
                    };
                case 1://兴业银行对私收款账号（行内）
                    return new ACCTTO
                    {
                        ACCTID = "622909117529613510",
                        INTERBANK = "Y",
                        LOCAL = "Y",
                        NAME = "小金人",
                    };
                case 2://普通转账、对公收款账号(跨行)
                    return new ACCTTO
                    {
                        ACCTID = "123455555",
                        INTERBANK = "N",
                        LOCAL = "Y",
                        NAME = "平安银行测试2222",
                        BANKDESC = "平安银行股份有限公司上海九江路支行",
                        CITY = "上海市"
                    };
                default://普通转账、对私收款账号(跨行)
                    return new ACCTTO
                    {
                        ACCTID = "6225885123771966",
                        INTERBANK = "N",
                        LOCAL = "Y",
                        NAME = "陈晨",
                        BANKDESC = "中国工商银行股份有限公司北京通州支行新华分理处",
                        CITY = "北京市"
                    };
            }
        }
        /// <summary>
        /// 3.4.2	查询转账交易状态
        /// </summary>
        public static void XFERINQTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.2", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_XFERINQTRNRQ, V1_XFERINQTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_XFERINQTRNRQ
            {
                XFERINQTRNRQ = new XFERINQTRNRQ
                {
                    TRNUID = tid,
                    CLTCOOKIE = "123",
                    XFERINQRQ = new XFERINQRQ
                    {
                        CLIENTREF = "20190117114159_3.4.1"
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.3	工资发放指令提交
        /// </summary>
        public static void RPAYOFFTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.3", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_RPAYOFFTRNRQ, V1_RPAYOFFTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_RPAYOFFTRNRQ
            {
                RPAYOFFTRNRQ = new RPAYOFFTRNRQ
                {
                    TRNUID = tid,
                    CLTCOOKIE = "123",
                    RPAYOFFRQ = new RPAYOFFRQ
                    {
                        RPAYOFFINFO = new RPAYOFFINFO<RPAYOFF>
                        {
                            ACCTFROM = new ACCTFROM
                            {
                                ACCTID = mainAccountId
                            },
                            TITLE = "工资发放",
                            DESCRIPTION = "006",
                            RPAYOFFLIST = new RPAYOFFLIST<RPAYOFF>
                            {
                                List = new List<RPAYOFF>()
                            },
                        }
                    }
                }
            };
            var acct = GetACCTTO(1);
            rq.SECURITIES_MSGSRQV1.RPAYOFFTRNRQ.RPAYOFFRQ.RPAYOFFINFO.RPAYOFFLIST.List.Add(
                new RPAYOFF
                {
                    INDX = 1,
                    ACCTID = acct.ACCTID,
                    ACCTNAME = acct.NAME,
                    TRNAMT = 2.2m
                });
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.4	工资发放指令查询
        /// </summary>
        public static void RPAYOFFINQTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.4", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_RPAYOFFINQTRNRQ, V1_RPAYOFFINQTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_RPAYOFFINQTRNRQ
            {
                RPAYOFFINQTRNRQ = new RPAYOFFINQTRNRQ
                {
                    TRNUID = tid,
                    CLTCOOKIE = "123",
                    XFERINQRQ = new XFERINQRQ
                    {
                        CLIENTREF = "20190117135721_3.4.3"
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.5	单笔托收、子账户托收、回款查询
        /// </summary>
        public static void GATHERTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.5", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_GATHERTRNRQ, V1_GATHERTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_GATHERTRNRQ
            {
                GATHERTRNRQ = new GATHERTRNRQ
                {
                    TRNUID = tid,
                    GATHERRQ = new GATHERRQ
                    {
                        GATHERINFO = new GATHERRQINFO
                        {
                            ACCTTO = new GATHERRQ_ACCTTO
                            {
                                ACCTID = mainAccountId,
                            },
                            FIRMCODE = "8778",
                            BIZCODE = "00100",
                            LIMITDAYS = 1,
                            TITLE = "单笔托收",
                            MEMO = "备注测试",
                            TRNTYPE = 1,
                            PAYINFO = new RQPAYINFO
                            {
                                INDX = 1,
                                CONTRACTID = "2016",
                                ACCTFROM = new CORRELATEACCT
                                {
                                    ACCTID = "117010100100107091",
                                    NAME = "test"
                                },
                                PAYMODE = 0,
                                APPLYAMT = 12.7m,
                                PURPOSE = "电费",
                            }
                        }
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.6	批量托收、批量子账户托收
        /// </summary>
        public static void FBBATCHGATHERTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.6", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_FBBATCHGATHERTRNRQ, V1_FBBATCHGATHERTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_FBBATCHGATHERTRNRQ
            {
                FBBATCHGATHERTRNRQ = new FBBATCHGATHERTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new FBBATCHGATHERTRN_RQBODY
                    {
                        ACCTID = mainAccountId,
                        FIRMCODE = "8778",
                        BIZCODE = "00100",
                        LIMITDAYS = 1,
                        TITLE = "批量托收",
                        MEMO = "批量备注",
                        TRNTYPE = 1,
                        USE = "收电费",
                        GATHERINFO = new List<FBBATCHGATHER_PAYINFO>
                        {
                            new FBBATCHGATHER_PAYINFO{
                                INDX =1,
                                CONTRACTID="2016",
                                ACCTFROM =new CORRELATEACCT{
                                    ACCTID = "117010100100107091",
                                    NAME = "test"
                                },
                                PAYMODE=0,
                                APPLYAMT=3.3m,
                                PURPOSE="电费1",
                                BIZCODE0="00100",
                                BIZCODE1="00100",
                                //BIZCODE2="00100", 切记此处不能输入BIZCODE2
                                MEMO ="电费1"
                            },
                            new FBBATCHGATHER_PAYINFO{
                                INDX =2,
                                CONTRACTID="20170510",
                                ACCTFROM =new CORRELATEACCT{
                                    ACCTID = "622908121000127611",
                                    NAME = "汪汪"
                                },
                                PAYMODE=0,
                                APPLYAMT=5.7m,
                                PURPOSE="电费2",
                                BIZCODE0="00100",
                                BIZCODE1="00100",
                                //BIZCODE2="00100", 切记此处不能输入BIZCODE2
                                MEMO ="电费2"
                            },
                        }
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.7	批量托收或子账户托收明细查询
        /// </summary>
        public static void FBBATCHSTMTTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.7", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_FBBATCHSTMTTRNRQ, V1_FBBATCHSTMTTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_FBBATCHSTMTTRNRQ
            {
                FBBATCHSTMTTRNRQ = new FBBATCHSTMTTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new FBBATCHSTMTTRN_RQBODY
                    {
                        ACCTID = mainAccountId,
                        CLIENTREF = "20190117160138_3.4.6",
                        PAGE = 1,
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.8	实时批量支付与批量费用(最多100笔)
        /// </summary>
        public static void RBATCHTRSFRTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.8", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_RBATCHTRSFRTRNRQ, V1_RBATCHTRSFRTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_RBATCHTRSFRTRNRQ
            {
                RBATCHTRSFRTRNRQ = new RBATCHTRSFRTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new RBATCHTRSFRTRN_RQBODY<RBATCHTRSFRTRNRQ_XFERINFO>
                    {
                        //TITLE= "实时批量支付与批量费用",
                        ACCTFROM = new ACCTFROM
                        {
                            ACCTID = mainAccountId
                        },
                        BIZTYPE = 0,
                        PURPOSE = "实时批量支付与批量费用",
                        List = new List<RBATCHTRSFRTRNRQ_XFERINFO>
                        {
                            new RBATCHTRSFRTRNRQ_XFERINFO{
                                INDX =1,
                                ACCTTO =GetACCTTO(0),
                                TRNAMT=1.1m,
                                USE="对公行内"
                            },
                            new RBATCHTRSFRTRNRQ_XFERINFO
                            {
                                INDX =2,
                                ACCTTO =GetACCTTO(1),
                                TRNAMT=2.2m,
                                USE="对私行内"
                            },
                            new RBATCHTRSFRTRNRQ_XFERINFO
                            {
                                INDX =3,
                                ACCTTO =GetACCTTO(2),
                                TRNAMT=3.2m,
                                USE="对公跨行"
                            },
                            new RBATCHTRSFRTRNRQ_XFERINFO
                            {
                                INDX =4,
                                ACCTTO =GetACCTTO(4),
                                TRNAMT=4.1m,
                                USE="对私跨行"
                            },
                        }
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.9	指令回单查询
        /// </summary>
        public static void RECEIPTTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.9", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_RECEIPTTRNRQ, V1_RECEIPTTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_RECEIPTTRNRQ
            {
                RECEIPTTRNRQ = new RECEIPTTRNRQ
                {
                    TRNUID = "20190117114159_3.4.1",
                    BIZTYPE = 1,
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.10	快速转账支付及其指令查询（不采用工作流）  3.4.10.3 快速转账支付ICTRANSFERTRNRQ
        /// </summary>
        public static void ICTRANSFERTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.10.3", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_ICTRANSFERTRNRQ, V1_ICTRANSFERTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_ICTRANSFERTRNRQ
            {
                ICTRANSFERTRNRQ = new ICTRANSFERTRNRQ
                {
                    TRNUID = tid,
                    XMPTRQ = new XMPTRQ<RQACCT>
                    {
                        XFERINFO = new XFERINFO
                        {
                            ACCTFROM = new ACCTFROM
                            {
                                ACCTID = mainAccountId
                            },
                            ACCTTO = GetACCTTO(3),
                            TRNAMT = 3.1m,
                            PURPOSE = "快速转账支付ICTRANSFERTRNRQ",
                            DTDUE = DateTime.Now,
                        }
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.10	快速转账支付及其指令查询（不采用工作流）3.4.10.5 支付指令查询ICTRANSFERINQTRNRQ请求
        /// </summary>
        public static void ICTRANSFERINQTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.10.5", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_ICTRANSFERINQTRNRQ, V1_ICTRANSFERINQTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_ICTRANSFERINQTRNRQ
            {
                ICTRANSFERINQTRNRQ = new ICTRANSFERINQTRNRQ
                {
                    TRNUID = tid,
                    XFERINQRQ = new XFERINQRQ
                    {
                        CLIENTREF = "20190117193801_3.4.10.3"
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.4.12	异步批量支付 (最多100笔，不采用工作流)
        /// </summary>
        public static void ASYNBATCHTRSFRTRNRQSample()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.4.12", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_ASYNBATCHTRSFRTRNRQ, V1_ASYNBATCHTRSFRTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_ASYNBATCHTRSFRTRNRQ
            {
                ASYNBATCHTRSFRTRNRQ = new ASYNBATCHTRSFRTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new ASYNBATCHTRSFRTRN_RQBODY
                    {
                        ACCTFROM = new ACCTFROM
                        {
                            ACCTID = mainAccountId
                        },
                        BIZTYPE = 1,
                        PURPOSE = "异步批量支付",
                    }
                }
            };
            var txt = new RQ_XFERINFOTEXT();
            var list = new List<PayeeInfo>();
            for (byte i = 0; i < 4; i++)
            {
                var acct = GetACCTTO(i);
                var info = new PayeeInfo
                {
                    Account = acct.ACCTID,
                    Name = acct.NAME,
                    IsCIB = acct.INTERBANK[0],
                    IsSameCity = acct.LOCAL[0],
                    BankCode = acct.BANKNUM,
                    BankName = acct.BANKDESC,
                    Address = acct.CITY,
                    Amount = i + 2.3m,
                    Purpose = "异步>批量" + i,
                };
                list.Add(info);
            }
            txt.SetList(list);
            rq.SECURITIES_MSGSRQV1.ASYNBATCHTRSFRTRNRQ.RQBODY.XFERINFOTEXT = txt;
            //rq.SECURITIES_MSGSRQV1.ASYNBATCHTRSFRTRNRQ.TRNUID = "20190117200215_3.4.12";//直接测试历史记录
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
            if (rs?.SECURITIES_MSGSRSV1.ASYNBATCHTRSFRTRNRS.RSBODY.XFERPRCSTS.XFERPRCCODE == XFERPRCCODEEnum.PAYOUT
                || rs?.SECURITIES_MSGSRSV1.ASYNBATCHTRSFRTRNRS.RSBODY.XFERPRCSTS.XFERPRCCODE == XFERPRCCODEEnum.PART_PAYOUT)
            {
                var rList = rs.SECURITIES_MSGSRSV1.ASYNBATCHTRSFRTRNRS.RSBODY.XFERINFOTEXT.GetList();
            }
        }
        #endregion

        #region 3.7	集团服务
        /// <summary>
        /// 3.7.1	集团支付
        /// </summary>
        public static void XPMTTRNRQSimple()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.7.1", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_XPMTTRNRQ, V1_XPMTTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_XPMTTRNRQ
            {
                XPMTTRNRQ = new XPMTTRNRQ
                {
                    TRNUID = tid,
                    XMPTRQ = new XMPTRQ<XPMTTRN_FUNDACCT>
                    {
                        FUNDACCT = new XPMTTRN_FUNDACCT
                        {
                            ACCTID = mainAccountId,
                            XPMTTYPE = 0,
                        },
                        XFERINFO = new XFERINFO
                        {
                            ACCTFROM = new ACCTFROM
                            {
                                ACCTID = mainAccountId,
                            },
                            ACCTTO = GetACCTTO(3),
                            TRNAMT = 7.7m,
                            PURPOSE = "集团支付",
                            DTDUE = DateTime.Now,
                        }
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        /// <summary>
        /// 3.7.2	成员交易明细查询
        /// </summary>
        public static void CMSTMTQUERYTRNRQSimple()
        {
            string tid = string.Format("{0:yyyyMMddHHmmss}_3.7.1", DateTime.Now);
            var rq = GetRequest<FOXRQ<V1_CMSTMTQUERYTRNRQ, V1_CMSTMTQUERYTRNRS>>();
            rq.SECURITIES_MSGSRQV1 = new V1_CMSTMTQUERYTRNRQ
            {
                CMSTMTQUERYTRNRQ = new CMSTMTQUERYTRNRQ
                {
                    TRNUID = tid,
                    RQBODY = new CMSTMTQUERYTRN_RQBODY
                    {
                        FUNDACCT = new RQACCT
                        {
                            ACCTID = mainAccountId
                        },
                        MBRACCT = new RQACCT
                        {
                            ACCTID = "117010100100050880"
                        },
                        DTEND = DateTime.Now.AddDays(-1),
                        DTSTART = DateTime.Now.AddDays(-2)
                    }
                }
            };
            var rs = client.Execute(rq);
            Console.WriteLine(rs?.ResponseContent);
        }
        #endregion
    }
}