using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andrean_Nastanliev_11e.Controllers
{
	interface IController<T, K>
	{
		public void Create(T type);
		public T Read(K key);
		public void Update(T type);
		public void Delete(K key);
		public List<T> ReadAll();

	}
}
