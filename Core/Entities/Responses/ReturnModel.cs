﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Responses
{
    public sealed class ReturnModel<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }
    }
}
