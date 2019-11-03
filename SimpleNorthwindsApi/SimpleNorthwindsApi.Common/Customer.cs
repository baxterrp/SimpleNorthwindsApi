﻿namespace SimpleNorthwindsApi.Common
{
    public class Customer
    {
        public string Id { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
