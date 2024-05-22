import { EventDto } from '../models/EventDto';
import { environment } from '../../../../../environments/environment';
export class EventService {

    AddEvent(event: EventDto) : any{
        return true;
    }

    GetAllEvent(): EventDto[]{
        return [];
    }
}