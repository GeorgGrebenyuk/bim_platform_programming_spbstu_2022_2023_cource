"""
Программирование для BIM-платформ
Курс от СПбПУ, 2022-2023; Цифровые кафедры
Модуль ЦК_М3_Работа с языками визуального программирования для автоматизации проектирования
тема 3: Python + COM API
Лекция 3.7: Работа с nanoCAD на примере оформления листов
"""
import win32com.client

nanocad_app = win32com.client.Dispatch("nanoCADx64.Application.22.0")
if nanocad_app is not None:
    ncad_doc = nanocad_app.ActiveDocument
    if ncad_doc is not None:
        for one_layout_index in range(0, ncad_doc.Layouts.Count, 1):
            ncad_Layout = ncad_doc.Layouts.Item(one_layout_index)
            if ncad_Layout.Name != "Model":
                ncad_Block_for_Layout = ncad_Layout.Block
                def insert_title_as_text(text_to_inserting):
                    size_of_layout = ncad_Layout.GetPaperSize()
                    center_text = str(size_of_layout[0]/2) + "," + str(size_of_layout[1] - 25) + ",0"
                    #print(center_text)
                    title_text_inst = ncad_Block_for_Layout.AddText(text_to_inserting, center_text, 5.0)
                    #print(center_text)
                    pass
                def modify_dyn_block(block_instance):
                    to_change = {
                        "РАЗРАБОТАЛ_ФАМИЛИЯ": "Иванов",
                        "РУКОВОДИТЕЛЬ_ФАМИЛИЯ": "Смирнов",
                        "ДАТА": "03.22",
                        "1": "03.22",
                        "2": "03.22",
                        "3": "03.22",
                        "4": "03.22",
                    }
                    for one_attr in block_instance.GetAttributes():
                        if one_attr.TagString in to_change.keys():
                            one_attr.TextString = to_change[one_attr.TagString]
                    pass
                #print(ncad_Layout.Name + " " + str(ncad_Block_for_Layout.Count))
                insert_title_as_text("Схема участка дороги")
                for object_at_block_index in range(0, ncad_Block_for_Layout.Count,1):
                    object_at_block = ncad_Block_for_Layout.Item(object_at_block_index )
                    if object_at_block.ObjectName == "AcDbBlockReference":
                        if object_at_block.EffectiveName == "штамп_Макорус":
                            #print("ok")
                            modify_dyn_block(object_at_block)


    else:
        print("Doc not running")
else:
    print("App not running")