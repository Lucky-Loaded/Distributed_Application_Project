﻿using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);


        // TODO: Add your service operations here


        [OperationContract]
        List<FilmDTO> GetFilms(string query);

        [OperationContract]
        string PostFilm(FilmDTO filmDto);

        [OperationContract]
        FilmDTO GetFilmByID(int id);

        [OperationContract]
        string DeleteFilm(int id);

       
        [OperationContract]
        List<UserDTO> GetUsers(string query);

        [OperationContract]
        string PostUser(UserDTO userDto);

        [OperationContract]
        UserDTO GetUserByID(int id);

        [OperationContract]
        string DeleteUser(int id);


        [OperationContract]
        List<OrderDTO> GetOrders(string query);

        [OperationContract]
        string PostOrder(OrderDTO orderDTO);

        [OperationContract]
        OrderDTO GetOrderByID(int id);

        [OperationContract]
        string DeleteOrder(int id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
