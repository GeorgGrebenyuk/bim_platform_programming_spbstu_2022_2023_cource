"""
Программирование для BIM-платформ
Курс от СПбПУ, 2022-2023; Цифровые кафедры
Модуль ЦК_М3_Работа с языками визуального программирования для автоматизации проектирования
тема 3: Python + COM API
Лекция 3.9: Пример работы с таблицами nanoCAD
"""
import win32com.client

def calc_block_ref(ncad_document):
    block2count = dict()
    for model_object in ncad_document.ModelSpace:
        if model_object.EntityName == 'AcDbBlockReference':
            object_as_BlockRef = win32com.client.CastTo(model_object, "IAcadBlockReference")
            if object_as_BlockRef is not None:
                if object_as_BlockRef.Name not in block2count.keys():
                    block2count[object_as_BlockRef.Name] = 1
                else:
                    block2count[object_as_BlockRef.Name] += 1
    print(block2count)
    return block2count




nanocad_app = win32com.client.Dispatch("nanoCADx64.Application.23.0")
if nanocad_app is not None:
    ncad_doc = nanocad_app.ActiveDocument
    if ncad_doc is not None:
        print(ncad_doc.Name)
        #Получаем таблицу блоков
        Blocks = ncad_doc.Database.Blocks
        Blocks_list = list()
        for one_block in Blocks:
            if one_block.Name[0] != '*':
                Blocks_list.append(one_block.Name)
        Blocks_list.sort()
        #Считаем вхождения блоков
        block2count = calc_block_ref(ncad_doc)

        #Для размещения таблицы
        need_layout = ncad_doc.Database.Layouts.Item(0)
        point_start = [0.54, 21.31]
        for one_layout in ncad_doc.Database.Layouts:
            if one_layout.Name == "Для вставки таблтиц":
                need_layout = one_layout
                break
        #СОздаем подпись и таблицу
        AcadText_object = need_layout.Block.AddText("Таблица количества вхождений блоков", point_start, 0.2)
        Acadtable_object = need_layout.Block.AddTable(point_start, len(Blocks_list) + 2, 2, 0.1, 3)
        Acadtable_object.SetText(0, 0, "Спецификация количества блоков")
        Acadtable_object.SetText(1, 0, "Имя блока")
        Acadtable_object.SetText(1, 1, "Число, шт.")
        counter_rows = 2
        for one_block_name in Blocks_list:
            Acadtable_object.SetText(counter_rows, 0, one_block_name)
            if one_block_name in block2count.keys():
                Acadtable_object.SetText(counter_rows, 1, block2count[one_block_name])
            else:
                Acadtable_object.SetText(counter_rows, 1, 0)
            counter_rows +=1
        print("End")
    else:
        print("Doc not running")
else:
    print("App not running")

