using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model
{
  public class StoryRole
  {
    public string Name { get; set; }
    public ConsoleColor Color { get; set; }
    public List<string> Experience { get; set; }
  }
}
