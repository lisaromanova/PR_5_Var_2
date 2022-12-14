# Конвертер валюты

Программа по переводу валюты позволяет переводить из рублей и копеек в доллары, евро, франки, рупии и иены, и обратно из приведенной иностранной валюты в рубли и копейки.

## Начало работы
Существует два варианта для просмотра проекта:<br/>
1. **Клонирование репозитория**
    + Зайти на репозиторий на Github [Конвертер валюты](https://github.com/lisaromanova/PR_5_Var_2) и скопировать ссылку из адресной строки.
2. **Открытие проекта из zip архива**
    + Зайти на репозиторий на Github и на вкладке *"Code"* выбрать пункт *"Download ZIP"*.

### Необходимые условия

Для того чтобы открыть проект необходимо скачать программу Visual Studio Community. Скачать ее можно бесплатно с [официального сайта](https://visualstudio.microsoft.com/ru/). В *"Загрузках"* необходимо найти установочный файл *"Visual Studio Installer"* и открыть его. После этого программа сама начнет устанавливаться. Для работы с проектом еще необходимо установить дополнительный пакет *"Компьютерная разработка на .NET"*

### Установка

1. **Клонирование репозитория**
    + В программе Visual Studio выбрать пункт *"Клонирование репозитория"*.
    + В поле *"Расположение репозитория"* вставить ссылку с Github.
    + В поле *"Путь"* указать путь расположения проекта на компьютере.
    + Нажать кнопку *"Клонировать"*. После этого проект автоматически откроется.
2. **Открытие проекта из zip архива**
    + Перейти в папку *"Загрузки"* и извлесь файлы из zip архива.
    + Открыть папку с проектом и найти в ней файл с расширением **.sln**.
    + Открыть этот файл с помощь программы Visual Studio. После этого проект автоматически откроется.
## Пример работы программы
![](https://github.com/lisaromanova/PR_5_Var_2/blob/master/PR_5_Var_2/Image.png)<br/>
Также в программе можно по данным из файла *"csv"* конвертировать валюту и получить результат в новый *"csv"* файл.<br/>
Пример метода чтения данных из *"csv"* файла: 
```C#
void GetData(string FilePath, List<MoneyString> L)
        {
            using (StreamReader stream = new StreamReader(FilePath))
            {
                while (stream.EndOfStream != true)
                {
                    string[] array = stream.ReadLine().Split(';');
                    AddItem(L, array[0], array[1], array[2], array[3], array[4], array[5], array[6]);
                }
            }
        }
```

Пример метода записи данных в *"csv"* файл: 
```C#
void PrintToFile(string FilePath, List<MoneyString> List)
        {
            using (StreamWriter stream = new StreamWriter(FilePath))
            {
                foreach (MoneyString u in List)
                {
                    stream.WriteLine(u.concat());
                }
            }
        }
```

## Авторы

+ **Романова Елизавета** - [Конвертер валюты](https://github.com/lisaromanova/PR_5_Var_2)

Информация о разработчике [Романова Елизавета](https://github.com/lisaromanova)
