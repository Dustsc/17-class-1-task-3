# 软件说明

运行"WpfApp1.exe".

备注：主程序运行先检查运行环境，然后生成备份文件"Library.bin"，之后从"Plugins"目录获取插件，编译生成文件存放在"CompiledAssemblies"目录下，加载插件。在插件第一次运行完成后生成json文件。

主程序的每一次运行均在"Logs"目录下生成与时间对应的日志文件。