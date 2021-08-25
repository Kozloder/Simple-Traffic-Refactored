using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic
{
    public class JobSafetyContainer<T> : IDisposable where T : struct, IDisposable
    {
        private T buffer1, buffer2;

        private T readPointer;
        private T writePointer;

        private bool locked = false;

        public JobSafetyContainer(Func<T> createFunc)
        {
            readPointer = buffer1 = createFunc();
            writePointer = buffer2 = createFunc();
        }

        public void Lock()
        {
            locked = true;
        }

        public void Unlock()
        {

        }

        public void Dispose()
        {
            buffer1.Dispose();
            buffer2.Dispose();
        }
        /*
        public static implicit operator T(JobSafetyContainer<T> container) 
        {
            return container.locked ? container.writePointer : 
        }
        public T AsWrite() 
        {
            return contai
        }*/
    }
}