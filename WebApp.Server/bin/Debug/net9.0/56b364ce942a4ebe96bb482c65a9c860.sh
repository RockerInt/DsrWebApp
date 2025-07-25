function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 40908;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 40908 > /dev/null;
done;

for child in $(list_child_processes 40916);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/jjimenez/Documents/Code/WebApp/WebApp.Server/bin/Debug/net9.0/56b364ce942a4ebe96bb482c65a9c860.sh;
