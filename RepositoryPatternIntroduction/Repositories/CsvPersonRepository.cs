﻿using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryPatternIntroduction.Backend.Entities;
using RepositoryPatternIntroduction.Backend.Interfaces;
using System.Configuration;
using System.IO;

namespace RepositoryPatternIntroduction.Backend.Repositories
{
    public class CsvPersonRepository : IRepository<IPerson>
    {
        private string _filePath;
        public CsvPersonRepository()
        {
            var fileName = ConfigurationManager.AppSettings["CsvFileName"];
            _filePath = AppDomain.CurrentDomain.BaseDirectory + "\\TestFiles\\" + fileName;
        }

        public bool Delete(IPerson entity)
        {
            try
            {
                List<String> lines = new List<string>();
                if (File.Exists(_filePath))
                {
                    using (var reader = new StreamReader(new FileStream(_filePath, FileMode.Open)))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string name = line.Split(",".ToCharArray())[0];
                            int age = int.Parse(line.Split(",".ToCharArray())[1]);
                            if (!(name == entity.Name && age == entity.Age)) //if not equal, rewrite
                            {
                                lines.Add(line);
                            }
                        }
                    }
                    using (StreamWriter writer = new StreamWriter(_filePath, false))
                    {
                        foreach (String line in lines)
                            writer.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }

        public void Save()
        {
            //placeholder
        }

        public void Dispose()
        {
            //placeholder
        }

        public IPerson Get(object id)
        {
            Person returnedPerson = null;

            if (File.Exists(_filePath))
            {
                    using (var reader = new StreamReader(new FileStream(_filePath, FileMode.Open)))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string name = line.Split(",".ToCharArray())[0];
                            if (name == (string)id)
                            {
                                return new Person()
                                {
                                    Name = name,
                                    Age = Int16.Parse(line.Split(",".ToCharArray())[1])
                                };
                            }
                        }
                    }
            }
            return returnedPerson;
        }

        public IQueryable<IPerson> GetAll()
        {
            List<Person> peopleList = new List<Person>();
            if (File.Exists(_filePath))
            {
                using (var reader = new StreamReader(new FileStream(_filePath, FileMode.Open)))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        peopleList.Add(
                            new Person()
                            {
                                Name = line.Split(",".ToCharArray())[0],
                                Age = Int32.Parse(line.Split(",".ToCharArray())[1])
                            });
                    }
                }
            }
            return peopleList.AsQueryable();
        }

        public bool Insert(IPerson entity)
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using (StreamWriter writer = new StreamWriter(_filePath,true))
                    {
                        writer.WriteLine(entity.Name + "," + entity.Age);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
