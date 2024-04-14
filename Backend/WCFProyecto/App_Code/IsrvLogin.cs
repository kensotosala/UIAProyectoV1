using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

[ServiceContract]
public interface IsrvLogin
{
    [OperationContract]
    void DoWork();

    [OperationContract]
    bool iniciarSesion(string usuario, string password);
}