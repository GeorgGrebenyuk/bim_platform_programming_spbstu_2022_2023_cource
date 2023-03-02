"""
Программирование для BIM-платформ
Курс от СПбПУ, 2022-2023; Цифровые кафедры
Модуль ЦК_М3_Работа с языками визуального программирования для автоматизации проектирования
тема 3: Python + COM API
Лекция 3.2: Устройство объектной модели Renga. Обзор возможностей API. Подключение к модели
"""
import os
import sys
import win32com.client

renga_app = win32com.client.Dispatch("Renga.Application.1")
print(renga_app.Project.FilePath)
