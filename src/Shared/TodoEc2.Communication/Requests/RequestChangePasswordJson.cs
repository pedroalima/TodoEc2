﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoEc2.Communication.Requests
{
    public class RequestChangePasswordJson
    {
        public string Password { get; set; } = string.Empty;

        public string NewPassword {  get; set; } = string.Empty;
    }
}
