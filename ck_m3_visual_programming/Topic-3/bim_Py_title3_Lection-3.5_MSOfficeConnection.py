"""
Программирование для BIM-платформ
Курс от СПбПУ, 2022-2023; Цифровые кафедры
Модуль ЦК_М3_Работа с языками визуального программирования для автоматизации проектирования
тема 3: Python + COM API
Лекция 3.5: Работа через COM API с MS Word и с MS Excel на примере json-свойств помещений Renga
"""
import win32com.client
import json
import os

#Фиксиация файловых путей для работы с доп. файлами
current_dir_path = os.getcwd()
sample_json_path = os.path.join(current_dir_path, 'renga_rooms_data.json')
sample_excel_path = os.path.join(current_dir_path, 'test_excel.xlsx')
sample_word_path = os.path.join(current_dir_path, 'test_word.docx')

def get_dict_data(mode, ref_dict):
    to_return_data = list()
    for k, v in ref_dict.items():
        if not isinstance(v, dict):
            if mode == 0:
                to_return_data.append(k)
            else:
                to_return_data.append(v)
        elif isinstance(v, dict):
            to_return_data += get_dict_data(mode, v)
    return to_return_data
def get_table_by_json():
    headers = list()
    rows = list()
    f = open(sample_json_path, 'r')
    row_dictionary = json.load(f)
    f.close()
    headers = get_dict_data(0, row_dictionary["159123"])
    for room_id, room_data in row_dictionary.items():
        rows.append(get_dict_data(1,room_data ))
    return headers, rows

file_table_representation = get_table_by_json()

def ms_excel_work():
    Excel_app = win32com.client.Dispatch("Excel.Application")
    Excel_app.DisplayAlerts = False
    Excel_app.Visible = True
    working_file = Excel_app.Workbooks.Add()
    active_sheet = working_file.ActiveSheet
    #Создать колонки из заголовков
    headers = file_table_representation[0]
    for one_header_index in range(0, len(headers), 1):
        cell_worrking = active_sheet.Cells(1, one_header_index + 1)
        cell_worrking.Value = headers[one_header_index]
        cell_worrking.ColumnWidth = 15
    #Заносим данные по всем комнатам
    rows = file_table_representation[1]
    for one_rows_index in range (0, len(rows), 1):
        one_row = rows[one_rows_index]
        for prop_value_index in range(0, len(one_row), 1):
            cell_worrking = active_sheet.Cells(one_rows_index + 2, prop_value_index + 1)
            cell_worrking.Value = one_row[prop_value_index]
    working_file.SaveAs(sample_excel_path)
    #working_file.Close()
    #Excel_app.Quit()
    pass

def ms_word_work():
    Word_app = win32com.client.Dispatch("Word.Application")
    Word_app.DisplayAlerts = False
    Word_app.Visible = True
    word_doc = Word_app.Documents.Add()
    word_doc.Activate()
    word_doc.PageSetup.Orientation = 0
    word_text = "Общая информация по квартирам из модели Renga \n"
    def append_to_text_property_data(prop_name):
        index_of_property = file_table_representation[0].index(prop_name)
        total_sum = 0.0
        for one_row in file_table_representation[1]:
            total_sum += float(one_row[index_of_property])
        return total_sum

    word_text += "Общее число комнат, шт. = " + str(len(file_table_representation[1])) + "\n"
    word_text += "Общий объем комнат, м3 =  " + str(append_to_text_property_data("GrossVolume")) + "\n"
    word_text += "Общая площадь комнат, м2 = " + str(append_to_text_property_data("GrossFloorArea")) + "\n"

    word_doc.Content.Text = word_text
    word_doc.Content.MoveEnd
    word_doc.SaveAs(sample_word_path)
    #word_doc.Close()
    #Word_app.Quit()
#ms_excel_work();
ms_word_work()
