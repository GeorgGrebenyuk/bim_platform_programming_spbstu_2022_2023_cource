"""
Программирование для BIM-платформ
Курс от СПбПУ, 2022-2023; Цифровые кафедры
Модуль ЦК_М3_Работа с языками визуального программирования для автоматизации проектирования
тема 3: Python + COM API
Лекция 3.8: Подключение к CS ModelStudio Трубопроводы (на платформе nanoCAD 22)
"""
import win32com.client

#Проверка, принадлежит ли объект MS
def is_ms_object(object_in_model):
    try:
        if object_in_model.Element is not None:
            return True
        else:
            return False
    except:
        return False

nanocad_app = win32com.client.Dispatch("nanoCADx64.Application.22.0")
if nanocad_app is not None:
    ncad_doc = nanocad_app.ActiveDocument
    if ncad_doc is not None:
        print("Doc is exist" + ncad_doc.Name)
        model_space = ncad_doc.ModelSpace
        for object_in_model in model_space:
            if is_ms_object(object_in_model):
                ms_object = object_in_model.Element
                #print(object_in_model.EntityName + " " + ms_object.Name)
                if object_in_model.EntityName == "vCSAxis":
                    o_as_IWrAxis = win32com.client.CastTo(object_in_model, "IWrAxis")
                    #print(o_as_IWrAxis.CountItems(True, True, True, True, True))
                if object_in_model.EntityName == "vCSNode":
                    o_as_IWrNodeElbow = win32com.client.CastTo(object_in_model, "IWrNodeElbow")
                    print(o_as_IWrNodeElbow.PipeLayer)
    else:
        print("Doc not running")
else:
    print("App not running")