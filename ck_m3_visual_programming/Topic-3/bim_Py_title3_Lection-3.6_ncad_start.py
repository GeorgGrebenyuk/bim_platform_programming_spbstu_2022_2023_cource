"""
Программирование для BIM-платформ
Курс от СПбПУ, 2022-2023; Цифровые кафедры
Модуль ЦК_М3_Работа с языками визуального программирования для автоматизации проектирования
тема 3: Python + COM API
Лекция 3.6:  Устройство объектной модели nanoCAD. Обзор возможностей API. Подключение к модели
"""

import win32com.client

nanocad_app = win32com.client.Dispatch("nanoCADx64.Application.22.0")#"nanoCAD.Application"
if nanocad_app is not None:
    ncad_doc = nanocad_app.ActiveDocument
    if ncad_doc is not None:
        print("Doc is exist" + ncad_doc.Name)
    else:
        print("Doc not running")
else:
    print("App not running")