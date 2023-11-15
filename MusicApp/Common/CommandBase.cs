using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MusicApp.Common
{
    public class CommandBase : ICommand
    {
        //背板 实现Icommand接口
        public event EventHandler CanExecuteChanged;  //中间委托 如果状态改变 把相应的改变信息封装发送给相应处理函数

        public bool CanExecute(object parameter)  //是否可以执行？

        {
            return DoCanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)  //执行的时候该咋办？

        {
            DoExecute?.Invoke(parameter);
        }

        public Action<object> DoExecute { get; set; }        //命令执行时该咋做
        public Func<object,bool> DoCanExecute { get; set; }  //Func类型的字段  判断命令是否可以执行

    }
}
