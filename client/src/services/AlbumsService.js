import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Album } from "@/models/Album.js"

class AlbumsService{
  async getAlbums() {
    const res = await api.get('api/albums')
    logger.log('Got Albums', res.data)
    const albums = res.data.map(pojo => new Album(pojo))
    AppState.albums = albums
  }

}
export const albumsService = new AlbumsService()