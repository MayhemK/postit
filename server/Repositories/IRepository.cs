namespace postit.Repositories;

public interface IRepository<T>
{
  List<T> GetAll();
  T GetById();
  T Create();
  bool Delete(int id);
  T Update(T updataData);
}