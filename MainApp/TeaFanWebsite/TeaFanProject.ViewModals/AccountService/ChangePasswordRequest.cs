﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaFanProject.ViewModals.AccountService
{
    public class ChangePasswordRequest
    {
        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}
