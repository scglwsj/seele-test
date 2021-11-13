using ConsighmentService.Clients.DO;
using ConsighmentService.Services.Models;

namespace ConsighmentService.Services.Interfaces;

public interface ITransferClient
{
    public TransferResponse Transfer(Transfer transfer);
}
