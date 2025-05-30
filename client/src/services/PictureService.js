import { AppState } from "@/AppState.js"
import { Picture } from "@/models/Picture.js"
import { api } from "./AxiosService.js"

class PictureService {
  async createPicture(pictureData) {
    const res = await api.post('api/pictures', pictureData)
    AppState.pictures.push(new Picture(res.data))
  }

  async getPicturesByAlbum(albumId) {
    const res = await api.get(`api/albums/${albumId}/pictures`)
    const pictures = res.data.map(pojo => new Picture(pojo))
    AppState.pictures = pictures
  }


}

export const picturesService = new PictureService