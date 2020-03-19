﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClienteService
    {
        Task Insert(ClienteDTO cliente);
        Task Update(ClienteDTO cliente);
        Task<List<ClienteDTO>> GetData();
        Task<List<ClienteDTO>> GetClientes();

    }
}
