﻿using ComunidadVecinal.Settings;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Linq.Expressions;

namespace ComunidadVecinal.Helpers
{
    public class BaseRepository<T> :
          IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public BaseRepository()
        {
            connection =
                 new SQLiteConnection(Constantes.DatabasePath,
                 Constantes.Flags);
            connection.CreateTable<T>();
        }

        public void DeleteItem(T item)
        {
            try
            {
                //connection.Delete(item);
                connection.Delete(item, true);
            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            connection.Close();
        }

        public T GetItem(int id)
        {
            try
            {
                return
                     connection.Table<T>()
                     .FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>()
                     .Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

        public List<T> GetItems()
        {
            try
            {
                return connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

        public List<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return connection.Table<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

        public void SaveItem(T item)
        {
            int result = 0;
            try
            {
                if (item.Id != 0)
                {
                    result =
                         connection.Update(item);
                    StatusMessage = string.Empty;
                }
                else
                {
                    result = connection.Insert(item);
                    StatusMessage = string.Empty;
                }

            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
        }

        public void SaveItemWithChildren(T item, bool recursive = false)
        {
            connection.InsertWithChildren(item, recursive);
        }

        public List<T> GetItemsWithChildren()
        {
            try
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }
    }
}
