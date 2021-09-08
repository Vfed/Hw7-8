using System;
using System.Collections.Generic;
using System.Text;

namespace Hw8
{
    public class Hotel
    {
        public string HotelName { get; private set; }
        public int RoomsNumber { get { return Rooms.Capacity; } }
        public List<Room> Rooms { get; set; }
        public List<Worker> Workers { get; set; }
        public List<ExtraService> ExtraServices { get; set; }
        public int FloorsCount { get; private set; }
        public Hotel(string name, int floors)
        {
            HotelName = name;
            FloorsCount = floors;
            Rooms = new List<Room>();
            Workers = new List<Worker>();
            ExtraServices = new List<ExtraService>();
        }
        //------------------Worker Action ----------------------//
        //Add Worker
        public void AddWorker(string name, int age, string position, List<string> languages)
        {
            Workers.Add(new Worker(name, age, position, languages));
        }
        //Show workers
        public void ShowWorkers() { }
        //Remove workers
        public void RemoveWorkers() { }


        //------------------ Service Action ----------------------//
        //Adds services
        public void AddService(string Name, bool active)
        {
            ExtraServices.Add(new ExtraService(Name, active));
        }
        //Show Extra Services
        public void ShowServices() { }
        //Remove Extra Services
        public void RemoveServices() { }
        //Edite Extra Services
        public void EditServices() { }

        //------------------Room Action ----------------------//
        //-----  Rooms ----------//
        //Add Room
        public void AddRoom (int floor, int beds, bool isPublic){ }
        //Edit Rooms
        public void EditRoom() { }
        //Remove Room
        public void RemoveRoom() { }

        //----- Show Rooms ----------//
        //Show Rooms
        public void ShowRooms() { }
        //Show Free Rooms
        public void ShowFreeRooms() { }
        //Show Occupied Rooms
        public void ShowOccupiedRooms() { }
        //Add Turist to Room
        //----- Turists ----------//
        public void AddTuristToRoom(){ }
        //Remove Turist from Room
        public void RemoveTuristFromRoom() { }
        //----- Furniture ----------// 
        //Add Furniture to Room
        public void AddFurnitureToRoom() { }
        //Remove Furniture from Room
        public void RemoveFurnitureFromRoom() { }

        //------------------Hotel Action ----------------------//
        //Action with Hotel
        public void HotelOpens() { }
    }

    public class Person 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> LanguageSpeaks { get; set; }
    }
    public class Worker : Person
    {
        public string Position { get; set; }
        public Worker(string name, int age, string position, List<string> languges)
        {
            Name = name;
            Age = age;
            Position = position;
            LanguageSpeaks = languges;
        }
    }
    public class Turist : Person
    {
        public string CountryFrom { get; set; }
        public Turist(string name, int age, string country, List<string> languges)
        {
            Name = name;
            Age = age;
            CountryFrom = country;
            LanguageSpeaks = languges;
        }
    }
    public class Room
    {
        public int RoomNumber { get; private set; }
        public bool IsPublick { get; set; }
        public int Beds { get; set; }
        public int Floor { get; set; }
        public List<Turist> Turists { get; set; }
        public List<string> furnitures { get; set; }
        public bool IsFree (){
            if (IsPublick)
            {
                return Turists.Capacity <= Beds ;
            }
            else
            {
                return Turists.Capacity > 0 ;
            }
        }
        public Room(int number, bool publicRoom, int bedsCount)
        {

        }
    }
    public class ExtraService 
    {
        public string Service { get; set; }
        public bool IsAwailable { get; set; }
        public ExtraService(string Name, bool active) 
        {
            Service = Name;
            IsAwailable = active;
        }
    }
}
