#!/usr/bin/python3
# -*- coding: utf-8 -*-

import os.path

from unittest import TestCase
from generator_qr_code.creator_qr_file import CreatorQRCode


class TestQRCodeCreation(TestCase):

    def test_create_qr_code_add_save_jpeg(self):
        creator = CreatorQRCode("This is a test", "")
        creator.add_data()
        path = "../qr_code/qr_code.jpg"
        creator.create_qr_image_and_save(path)
        is_saving = False

        if os.path.isfile(path):
            is_saving = True

        self.assertTrue(is_saving)

