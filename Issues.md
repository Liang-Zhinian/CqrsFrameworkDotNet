Issues:

1. didn't find “dotnet” command
Solution: ln -s /usr/local/share/dotnet/dotnet /usr/local/bin/


2. No executable found matching command "dotnet-ef"
Solution: Add package Microsoft.EntityFrameworkCore.Tools


Install RabbitMQ:
brew install rabbitmq

Bash completion has been installed to:
/usr/local/etc/bash_completion.d

To have launchd start rabbitmq now and restart at login:
brew services start rabbitmq
Or, if you don't want/need a background service you can just run:
rabbitmq-server



启动插件
user@localhost:/usr/local/Cellar/rabbitmq/3.5.3/sbin> ./rabbitmq-plugins enable rabbitmq_management

默认可是可以再本地登陆，使用guest用户，密码也是guest. http://localhost:15672
