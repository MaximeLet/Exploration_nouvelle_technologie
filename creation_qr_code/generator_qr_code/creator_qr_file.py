import qrcode
from PIL import Image


class CreatorQRCode:
    qr = qrcode.QRCode(
        version=1,
        error_correction=qrcode.constants.ERROR_CORRECT_L,
        box_size=10,
        border=4,
    )

    def __init__(self, data, filename):
        self.data = data
        self.filename = filename

    def add_data(self):
        self.qr.add_data(self.data)
        self.qr.make(fit=True)

    def create_qr_image_and_save(self, path):
        qr_code = self.qr.make_image()
        if path == "":
            qr_code.save("qr_code/" + self.filename, "JPEG")
        else:
            qr_code.save(path, "JPEG")

if __name__ == "__main__":
    data = raw_input("Entrez votre texte: ")
    fileName = raw_input("Entrez le nom de votre fichier sans .jpg: ")
    app = CreatorQRCode(data, fileName + ".jpg")
    app.add_data()
    app.create_qr_image_and_save("")