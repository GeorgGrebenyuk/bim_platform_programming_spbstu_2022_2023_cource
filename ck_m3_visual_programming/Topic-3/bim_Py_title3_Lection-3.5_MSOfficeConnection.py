"""
Программирование для BIM-платформ
Курс от СПбПУ, 2022-2023; Цифровые кафедры
Модуль ЦК_М3_Работа с языками визуального программирования для автоматизации проектирования
тема 3: Python + COM API
Лекция 3.5: Работа через COM API с MS Word и с MS Excel на примере json-свойств помещений Renga
"""
import win32com.client
import json

sample_json_path = r'C:\Users\Georg\Documents\GitHub\bim_platform_programming_spbstu_2022_2023_cource' \
                   r'\ck_m3_visual_programming\Topic-3\renga_rooms_data.json'

#Преобразование json в табличный вид
def get_dict_data(key_or_value, source_dict):
    to_return_data = []
    for k,v in source_dict.items():
        if not isinstance(v, dict):
            if key_or_value == 0:
                to_return_data.append(k)
            else:
                to_return_data.append(v)
        elif isinstance(v, dict):
            to_return_data += get_dict_data(key_or_value, v)
    return to_return_data
    pass
def get_table_by_json():
    headers = list()
    rows = list()
    f = open(sample_json_path, 'r')
    row_dictionary = json.load(f)
    f.close()
    #Обновляем заголовочные строки на примере первой записи
    headers = get_dict_data(0, row_dictionary["159123"])
    print(str(headers))
    #for room_id, room_data in row_dictionary.items():

    pass


get_table_by_json()