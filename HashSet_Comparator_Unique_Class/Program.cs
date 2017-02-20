namespace HashSet_Comparator_Unique_Class
{
  using System;
  using System.Collections.Generic;
  class Row
  {
    public int Code;
    public string Stoka;
    public string Grupa;
    public string Cen_List;
    public string Other;
    public Row(int code, string grupa, string stoka, string cen_list, string other)
    {
      this.Code = code;
      this.Grupa = grupa;
      this.Stoka = stoka;
      this.Cen_List = cen_list;
      this.Other= other;
    }
    public override bool Equals(object obj)
    {
      //var item = obj as Row;
      if (obj == null || GetType() != obj.GetType())
      {
        return false;
      }
      Row p = (Row)obj;
      return (  this.Code.Equals(p.Code)   && this.Cen_List.Equals(p.Cen_List)
             && this.Stoka.Equals(p.Stoka) &&this.Grupa.Equals(p.Grupa) );
      //  return this.Code.Equals(item.Code);
      //  return base.Equals(obj);
    }
    public override int GetHashCode()
    {
      return this.Code.GetHashCode() ^ this.Stoka.GetHashCode()
           ^ this.Grupa.GetHashCode()^ this.Cen_List.GetHashCode();
    }

    public override string ToString()
    {
      return $"Code:{this.Code} Grupa:{Grupa} Stoka:{Stoka} Cen Lista:{this.Cen_List} Other:{this.Other}";
    }
  }
  public class Program
  {
    static void Main()
    {
      HashSet<Row> unique_rows = new HashSet<Row>();

      Row row1 = new Row(1, "Захарни1", "Вафла", "Промо","213");
      Row row2 = new Row(1, "Захарни1", "Вафла", "Промо","213");
      Row row3 = new Row(1, "Захарни1", "Вафла2", "Промо1","110");
      Row row4 = new Row(1, "Захарни1", "Вафла2", "Промо1", "1101");
      Row row5 = null;


      List<Row> lists = new List<Row> { row1, row2, row3, row4, row5 };

      foreach (var item in lists)
      {
        if (!unique_rows.Contains(item))
        {
          unique_rows.Add(item);
        }

      }
      //unique_rows.Add(new Row(1, "Захарни1", "Вафла1", "Промо1"));
      //unique_rows.Add(new Row(2, "Захарни" , "Вафла" , "Промо" ));
      //unique_rows.Add(new Row(2, "Захарни" , "Вафла" , "Промо" ));
      //unique_rows.Add(new Row(3, "Захарни" , "Вафла" , "Промо" ));
      //unique_rows.Add(new Row(3, "Захарни" , "Вафла" , "Промо" ));
     
      foreach (var item in unique_rows)
      {
        Console.WriteLine(item);
      }

    }
  }
}
