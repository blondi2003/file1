# file
# Лабораторная работа "Файлы".
## Ershova — вариант 4.
### Упражнение 1
Даны текстовые файлы «Text.txt» и «Table.csv». Программа должна загрузить файлы и сделать анализ данных. Результаты нужно сохранить в текстовые файлы и распределить по директориям для каждого задания, директории должны создаваться программой.
Используйте классы File, Directory, Path, FileInfo, Directory, DirectoryInfo, Path, StreamReader, StreamWriter, JsonSerializer;

Проанализировать текст «Text.txt». Файл должен быть не короче 500 символов, должен содержать строки. Результатом работы программы является текстовой файл «Result.txt» со следующей информацией:
 Название файла «Text.txt».
Абсолютный путь к файлу «Text.txt».
Относительный путь к файлу «Text.txt».
Время создания файла «Text.txt».
Размер файла «Text.txt».
Общее количество строк.
Общее количество слов.
Присутствуют ли в тексте цифры.
Присутствует ли в тексте кириллица.
Присутствует ли в тексте латиница.


### Упражнение 2
Создать в программе Excel/Google Tables файл «Table.csv», файл должен содержать данные о сущностях. Для чтения и записи используйте классы потока StreamReader, StreamWriter. Программа должна на основе данных о сущности рассчитать новые параметры. Результаты записать в текстовый файл «Result.csv». Рекомендуется взять сущность из области экономики: 
компания, 
завод, 
сотрудник 
и.т.д.
Количество строк с данными не менее 6.

В моем случае: сотрудники компании

### Задание 3
Загрузите файл «Table.csv». Сериализуйте в JSON формат данные о сущностях и сохраните в файл «Result.json».




