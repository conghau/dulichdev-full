using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDuLichDev.Enum
{
    public enum PageInfo
    {
        Message,
        Page,
        PageSize,
        PageNum,
        TotalRecord,
        OrderBy,
        OrderDirection,
        PageInfo,
        Act,
        Action,
        Previous
    }

    public enum ResultMessage
    {
        SUC_Insert,
        SUC_Update,
        ERR_Insert,
        ERR_Update,
        ERR_Exist,

    }
}